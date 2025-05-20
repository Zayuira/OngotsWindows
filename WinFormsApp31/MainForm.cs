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


    public MainForm()
    {
        InitializeComponent();
        AddFlightListFlowPanel();

    }
    private async Task LoadFlightsFromApiAsync()
    {
        string apiUrl = "http://localhost:5000/api/flights";// API-ийн чинь URL

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

                // DTO-оос Domain Model руу хөрвүүлэлт
                flights = flightDtos.Select(dto => new Flight(
                    dto.Id,
                    dto.Number,
                    Enum.TryParse(dto.Status, out Flight.FlightStatusEnum status) ? status : Flight.FlightStatusEnum.Registering,
                    new List<Passenger>(), new List<Seat>() // TODO: Суудлын жагсаалтыг дараа холбоно
                )).ToList();

                AddFlightListFlowPanel(); // UI-д харуулах
            }
            catch (Exception ex)
            {
                MessageBox.Show("Flight өгөгдөл авах үед алдаа гарлаа: " + ex.Message);
            }
        }
    }
    //private void AddFlightListFlowPanel()
    //{
    //    FlightListFlowPanel.Controls.Clear();

    //    foreach (var flight in flights)
    //    {
    //        var dto = new FlightDtos
    //        {
    //            Id = flight.Id,
    //            Number = flight.Number,
    //            Status = flight.Status.ToString(),
    //            TotalSeats = flight.Seats.Count,
    //            AssignedSeats = flight.Seats.Count(s => s.IsAssigned)
    //        };

    //        var flightPanel = new Panel
    //        {
    //            Width = FlightListFlowPanel.ClientSize.Width - 10,
    //            Height = 90,
    //            BorderStyle = BorderStyle.FixedSingle,
    //            BackColor = Color.White,
    //            Margin = new Padding(5),
    //            Cursor = Cursors.Hand
    //        };

    //        var lblNumber = new Label
    //        {
    //            Text = $"Нислэг: {dto.Number}",
    //            Font = new Font("Segoe UI", 10, FontStyle.Bold),
    //            Location = new Point(10, 10),
    //            AutoSize = true
    //        };

    //        var lblStatus = new Label
    //        {
    //            Text = $"Төлөв: {dto.Status}",
    //            Font = new Font("Segoe UI", 9),
    //            Location = new Point(10, 30),
    //            AutoSize = true,
    //            ForeColor = Color.DarkGreen
    //        };

    //        var lblSeats = new Label
    //        {
    //            Text = $"Суудал: {dto.AssignedSeats}/{dto.TotalSeats} (Сул: {dto.AvailableSeats})",
    //            Font = new Font("Segoe UI", 9),
    //            Location = new Point(10, 50),
    //            AutoSize = true
    //        };

    //        flightPanel.Controls.Add(lblNumber);
    //        flightPanel.Controls.Add(lblStatus);
    //        flightPanel.Controls.Add(lblSeats);

    //        flightPanel.Click += (s, e) =>
    //        {
    //            tableLayoutPanel1.Visible = true;
    //            // TODO: Flight дэлгэрэнгүй мэдээлэл гаргах хэсгийг хэрэгжүүлэх
    //        };

    //        FlightListFlowPanel.Controls.Add(flightPanel);
    //    }
    //}

    private void AddFlightListFlowPanel()
    {
        FlightListFlowPanel.Controls.Clear();

        foreach (var dto in flightDtos) // ✅ flightDtos-г шууд ашиглана
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
                Text = $"Суудал: {dto.AssignedSeats}/{dto.TotalSeats} (Сул: {dto.AvailableSeats})",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 50),
                AutoSize = true
            };

            var lblPassengers = new Label
            {
                Text = $"Зорчигчид: {dto.PassengersCount} хүн",
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
                // TODO: Flight дэлгэрэнгүй мэдээлэл гаргах хэсгийг хэрэгжүүлэх
            };

            FlightListFlowPanel.Controls.Add(flightPanel);
        }
    }


    private async void Form1_Load(object sender, EventArgs e)
    {
        await LoadFlightsFromApiAsync();
        blazorWebView1.WebView.Source = new Uri(_hubUrl);
        //label_ConnectionStatus.Text = _hubConnection.State.ToString();
    }


    private void ChangeStateButton_Click(object sender, EventArgs e)
    {
        using (var stateChangeForm = new StateChangeForm())
        {
            stateChangeForm.ShowDialog();
        }
    }
    //BOLGONODOOOOOOOOOOOOOOOO
    private void SearchButton_Click(object sender, EventArgs e)
    {
        try
        {
            // Clear previous search results
            ResultPassengerFlowPanel.Controls.Clear();

            string searchPassport = SearchTextBox.Text?.Trim();

            if (string.IsNullOrEmpty(searchPassport))
            {
                MessageBox.Show("Паспортын дугаараа оруулна уу.");
                return;
            }

            PassengerDto foundPassenger = null;

            foreach (var flight in flightDtos)
            {
                MessageBox.Show($"NIIT PASSENGER{flight.PassengersCount}");
                foundPassenger = flight.Passengers?.FirstOrDefault(p =>
                    !string.IsNullOrEmpty(p.PassportNumber) &&
                    p.PassportNumber.Equals(searchPassport, StringComparison.OrdinalIgnoreCase));

                if (foundPassenger != null)
                {
                    Console.WriteLine($"[DEBUG] Flight: {flight.Number}, Passenger: {foundPassenger.Name}, Passport: {foundPassenger.PassportNumber}");
                    break;
                }
            }

            if (foundPassenger != null)
            {
                CreatePassengerInfo(foundPassenger);
            }
            else
            {
                CreateNotFoundPanel();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
            MessageBox.Show("Хайлт хийх явцад алдаа гарлаа. Алдааны мэдээлэл: " + ex.Message,
                            "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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

        passengerInfoPanel.Controls.Add(lblPassengerName);
        passengerInfoPanel.Controls.Add(lblPassportNumber);
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

}
