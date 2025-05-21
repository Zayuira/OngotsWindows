using System.Text;
using System.Text.Json;
using FlightLibrary;
using FlightLibrary.DTO;
using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormsApp31;

public partial class MainForm : Form
{
    private readonly string _hubUrl = "https://localhost:7227/flightstatusdisplay";
    HubConnection _hubConnection;
    List<Flight> flights = new List<Flight>();
    List<FlightDtos> flightDtos = new List<FlightDtos>();
    PassengerDto PassengerDto = new PassengerDto();

    private Button? selectedSeatButton = null;
    private string? selectedSeatNumber = null;
    private FlightDtos? currentFlightDto = null;

    public MainForm()
    {
        InitializeComponent();
        AddFlightListFlowPanel();
    }

    private async Task LoadFlightsFromApiAsync()
    {
        string apiUrl = "http://localhost:5000/api/flights";
        using (HttpClient client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();
                flightDtos = JsonSerializer.Deserialize<List<FlightDtos>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                flights = flightDtos.Select(dto => new Flight(
                    dto.Id,
                    dto.Number,
                    Enum.TryParse(dto.Status, out Flight.FlightStatusEnum status) ? status : Flight.FlightStatusEnum.Registering,
                    new List<Passenger>(), new List<Seat>()
                )).ToList();

                AddFlightListFlowPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Flight өгөгдөл авах үед алдаа гарлаа: " + ex.Message);
            }
        }
    }

    private void AddFlightListFlowPanel()
    {
        FlightListFlowPanel.Controls.Clear();
        foreach (var dto in flightDtos)
        {
            var flightPanel = new Panel
            {
                Width = FlightListFlowPanel.ClientSize.Width - 10,
                Height = 110,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(5),
                Cursor = Cursors.Hand
            };

            var lblNumber = new Label
            {
                Text = $"Нислэг: {dto.Number}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblStatus = new Label
            {
                Text = $"Төлөв: {dto.Status}",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 30),
                AutoSize = true,
                ForeColor = Color.DarkGreen
            };

            var lblSeats = new Label
            {
                Text = $"Баталгаажсан Суудлууд: {dto.AssignedSeats}/{dto.TotalSeats} (Сул: {dto.AvailableSeats})",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 50),
                AutoSize = true
            };

            var lblPassengers = new Label
            {
                Text = $"Захиалсан зорчигчид: {dto.PassengersCount} хүн",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 70),
                AutoSize = true
            };

            flightPanel.Controls.Add(lblNumber);
            flightPanel.Controls.Add(lblStatus);
            flightPanel.Controls.Add(lblSeats);
            flightPanel.Controls.Add(lblPassengers);

            flightPanel.Click += (s, e) =>
            {
                tableLayoutPanel1.Visible = true;
                currentFlightDto = dto; // ШИНЭ: сонгосон нислэгийг хадгална
                ShowFlightSeats(dto);
            };

            FlightListFlowPanel.Controls.Add(flightPanel);
        }
    }

    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadFlightsFromApiAsync();
        blazorWebView1.WebView.Source = new Uri(_hubUrl);
    }

    private void ChangeStateButton_Click(object sender, EventArgs e)
    {
        using (var stateChangeForm = new StateChangeForm())
        {
            stateChangeForm.ShowDialog();
        }
    }

    private void SearchButton_Click(object sender, EventArgs e)
    {
        try
        {
            CheckButton.Enabled = true;
           
            ResultPassengerFlowPanel.Controls.Clear();
            FlightListFlowPanel.Controls.Clear();

            string searchPassport = SearchTextBox.Text?.Trim();

            if (string.IsNullOrEmpty(searchPassport))
            {
                MessageBox.Show("Паспортын дугаараа оруулна уу.");
                AddFlightListFlowPanel();
                return;
            }

            var allPassengers = flightDtos.SelectMany(f => f.Passengers).ToList();
            var foundPassenger = allPassengers.FirstOrDefault(p =>
                !string.IsNullOrEmpty(p.PassportNumber) &&
                p.PassportNumber.Equals(searchPassport, StringComparison.OrdinalIgnoreCase));
            PassengerDto = foundPassenger;
            if (foundPassenger != null)
            {
                var passengerFlight = flightDtos.FirstOrDefault(f =>
                    f.Passengers.Any(p =>
                        !string.IsNullOrEmpty(p.PassportNumber) &&
                        p.PassportNumber.Equals(searchPassport, StringComparison.OrdinalIgnoreCase)));
                MessageBox.Show($"{foundPassenger.SeatCode}");
                if (PassengerDto.SeatCode != null)
                {
                    CheckButton.Enabled = false;
                    CheckButton.BackColor = SystemColors.Control;
                }
                else
                {
                    CheckButton.Enabled = true ;
                }
                if (passengerFlight != null)
                {
                    
                    DrawSingleFlightOnPanel(passengerFlight);
                }
                else
                {
                    DrawNoFlightPanel();
                }
                
                CreatePassengerInfo(foundPassenger);
            }
            else
            {
                CreateNotFoundPanel();
                DrawNoFlightPanel();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Хайлт хийх явцад алдаа гарлаа. Алдааны мэдээлэл: " + ex.Message,
                            "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DrawSingleFlightOnPanel(FlightDtos dto)
    {
        FlightListFlowPanel.Controls.Clear();

        var flightPanel = new Panel
        {
            Width = FlightListFlowPanel.ClientSize.Width - 10,
            Height = 110,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White,
            Margin = new Padding(5),
            Cursor = Cursors.Hand
        };

        var lblNumber = new Label
        {
            Text = $"Нислэг: {dto.Number}",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Location = new Point(10, 10),
            AutoSize = true
        };

        var lblStatus = new Label
        {
            Text = $"Төлөв: {dto.Status}",
            Font = new Font("Segoe UI", 9),
            Location = new Point(10, 30),
            AutoSize = true,
            ForeColor = Color.DarkGreen
        };

        var lblSeats = new Label
        {
            Text = $"Баталгаажсан Суудлууд: {dto.AssignedSeats}/{dto.TotalSeats} (Сул: {dto.AvailableSeats})",
            Font = new Font("Segoe UI", 9),
            Location = new Point(10, 50),
            AutoSize = true
        };

        var lblPassengers = new Label
        {
            Text = $"Захиалсан зорчигчид: {dto.PassengersCount} хүн",
            Font = new Font("Segoe UI", 9),
            Location = new Point(10, 70),
            AutoSize = true
        };

        flightPanel.Controls.Add(lblNumber);
        flightPanel.Controls.Add(lblStatus);
        flightPanel.Controls.Add(lblSeats);
        flightPanel.Controls.Add(lblPassengers);

        flightPanel.Click += (s, e) =>
        {
            tableLayoutPanel1.Visible = true;
            currentFlightDto = dto; // ШИНЭ: сонгосон нислэг хадгална
            ShowFlightSeats(dto);
        };

        FlightListFlowPanel.Controls.Add(flightPanel);
    }

    private void ShowFlightSeats(FlightDtos flight)
    {
        foreach (Control control in tableLayoutPanel1.Controls)
        {
            if (control is Button seatButton)
            {
                string seatCode = seatButton.Text.Trim();
                var seat = flight.Seats.FirstOrDefault(s =>
                    s.SeatNumber.Trim().Equals(seatCode, StringComparison.OrdinalIgnoreCase));

                bool isReserved = flight.Passengers.Any(p => p.SeatCode == seatCode);

                if (seat != null && isReserved)
                {
                    seatButton.Enabled = false;
                    seatButton.BackColor = Color.LightGray;
                }
                else
                {
                    seatButton.Enabled = true;
                    seatButton.BackColor = SystemColors.Control;
                }
            }
        }
    }
    private void DrawNoFlightPanel()
    {
        FlightListFlowPanel.Controls.Clear();

        var noFlightPanel = new Panel
        {
            Width = 350,
            Height = 60,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.LightYellow,
            Margin = new Padding(5)
        };

        var lblNoFlight = new Label
        {
            Text = "Энэ зорчигч нислэг захиалаагүй байна.",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = Color.Red,
            Location = new Point(10, 10),
            AutoSize = true
        };

        noFlightPanel.Controls.Add(lblNoFlight);
        FlightListFlowPanel.Controls.Add(noFlightPanel);
    }
    private void CreatePassengerInfo(PassengerDto passenger)
    {
        var passengerInfoPanel = new Panel
        {
            Width = 300,
            Height = 100,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.White,
            Margin = new Padding(5),
            Cursor = Cursors.Hand
        };
        var lblPassengerName = new Label
        {
            Text = $"Зорчигчийн нэр: {passenger.Name}",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            Location = new Point(10, 10),
            AutoSize = true
        };
        var lblPassportNumber = new Label
        {
            Text = $"Паспортын дугаар: {passenger.PassportNumber}",
            Font = new Font("Segoe UI", 9),
            Location = new Point(10, 40),
            AutoSize = true
        };
        var lbluserSeatnumber = new Label
        {
            Text = $"Зорчигчийн суудал: {passenger.SeatCode}",
            Font = new Font("Segoe UI", 9),
            Location = new Point(10, 70),
            AutoSize = true
        };

        passengerInfoPanel.Controls.Add(lblPassengerName);
        passengerInfoPanel.Controls.Add(lblPassportNumber);
        passengerInfoPanel.Controls.Add(lbluserSeatnumber);
        ResultPassengerFlowPanel.Controls.Add(passengerInfoPanel);
      
    }

    private void CreateNotFoundPanel()
    {
        var notFoundPanel = new Panel
        {
            Width = 300,
            Height = 60,
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = Color.LightYellow,
            Margin = new Padding(5)
        };
        var lblNotFound = new Label
        {
            Text = "Мэдээлэл олдсонгүй",
            Font = new Font("Segoe UI", 10, FontStyle.Bold),
            ForeColor = Color.Red,
            Location = new Point(10, 10),
            AutoSize = true
        };

        notFoundPanel.Controls.Add(lblNotFound);
        ResultPassengerFlowPanel.Controls.Add(notFoundPanel);
    }

    private void PrintButton_Click(object sender, EventArgs e)
    {
        using (var Form1 = new Form1())
        {
            Form1.ShowDialog();
        }
    }

    // Бүх суудлын button-д энэ handler-г онооно уу!
    private void Seat1_Click(object sender, EventArgs e)
    {
        Button button = sender as Button;
        if (button == null || currentFlightDto == null) return;

        if (selectedSeatButton != null && selectedSeatButton != button)
        {
            selectedSeatButton.Enabled = true;
            selectedSeatButton.BackColor = SystemColors.Control;
        }

        selectedSeatButton = button;
        selectedSeatNumber = button.Text;

        button.BackColor = Color.LightSkyBlue;

        var seat = currentFlightDto.Seats.FirstOrDefault(s =>
            s.SeatNumber.Trim().Equals(button.Text.Trim(), StringComparison.OrdinalIgnoreCase));
        if (seat != null)
        {
            PassengerDto.SeatCode = seat.SeatNumber;
            PassengerDto.SeatId = seat.Id; // PassengerDto-д SeatId талбар байх ёстой!
        }

        ResultPassengerFlowPanel.Controls.Clear();
        CreatePassengerInfo(PassengerDto);
    }

    private async void CheckButton_Click(object sender, EventArgs e)
    {
        
        if (PassengerDto == null || PassengerDto.Id == 0)
        {
            MessageBox.Show("Зорчигч сонгогдоогүй байна.");
            return;
        }

        if (string.IsNullOrEmpty(selectedSeatNumber) || selectedSeatButton == null)
        {
            MessageBox.Show("Суудал сонгоно уу.");
            return;
        }

        // Find SeatId from current flight using selected seat code
        var seat = currentFlightDto?.Seats?.FirstOrDefault(s => s.SeatNumber == selectedSeatNumber);
        if (seat == null)
        {
            MessageBox.Show("Суудал олдсонгүй.");
            return;
        }

        try
        {
            var request = new { SeatId = seat.Id };
            string jsonRequest = JsonSerializer.Serialize(request);

            using var client = new HttpClient();
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"http://localhost:5000/api/passenger/{PassengerDto.Id}/seat", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Суудлыг амжилттай шинэчиллээ.");
                await LoadFlightsFromApiAsync(); // Refresh data
            
            }
            
            else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                MessageBox.Show("Зорчигч эсвэл суудал олдсонгүй.");
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Алдаа: " + error);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Шинэчлэх үед алдаа гарлаа: " + ex.Message);
        }
    }


 


}