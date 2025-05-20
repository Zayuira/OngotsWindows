using FlightLibrary;
using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormsApp31;

public partial class MainForm : Form
{
    //private readonly string _url = "http://localhost:5000/flightstatushub";
    private readonly string _hubUrl = "https://localhost:7227/flightstatusdisplay";
    HubConnection _hubConnection;
    List<Flight> flights = new List<Flight>();
   

    public MainForm()
    {
        InitializeComponent();
        LoadFlights(); 
        AddFlightListFlowPanel();

    }
    private void LoadFlights()
    {
        Flight flight1 = new Flight(1, "MNG101", "Бүртгэж байна", new List<Passenger>(), new List<Seat>());
        Flight flight2 = new Flight(2, "MNG202", "Онгоцонд сууж байна", new List<Passenger>(), new List<Seat>());
        Flight flight3 = new Flight(3, "MNG303", "Хойшилсон", new List<Passenger>(), new List<Seat>());

        // Суудал үүсгэх
        Seat seat1 = new Seat(1, "1A", false, 1, flight1);
        Seat seat2 = new Seat(2, "1B", true, 1, flight1);
        Seat seat3 = new Seat(3, "2A", false, 2, flight2);
        Seat seat4 = new Seat(4, "2B", false, 2, flight2);
        Seat seat5 = new Seat(5, "3A", true, 3, flight3);
        Seat seat6 = new Seat(6, "3B", false, 3, flight3);
        flights.Add(flight1);
        flights.Add(flight2);
        flights.Add(flight3);
        Passenger passenger1 = new Passenger(1, "AB123456", "Bat-Erdene", 2, 1, seat2, flight1);
        Passenger passenger2 = new Passenger(2, "CD654321", "Anu", null, 1, null, flight1);
        Passenger passenger3 = new Passenger(3, "EF112233", "Ganbaatar", null, 2, null, flight2);
        Passenger passenger4 = new Passenger(4, "GH334455", "Solongo", null, 2, null, flight2);
        Passenger passenger5 = new Passenger(5, "IJ556677", "Tugs", 5, 3, seat5, flight3);
    }
    private void AddFlightListFlowPanel()
    {
        FlightListFlowPanel.Controls.Clear();

        foreach (var flight in flights)
        {
            var flightPanel = new Panel
            {
                Width = FlightListFlowPanel.ClientSize.Width - 10,
                Height = 70,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(5),
                Cursor = Cursors.Hand // Дээр дарж болдог харагдац
            };

            var lblNumber = new Label
            {
                Text = $"Нислэг: {flight.Number}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 10),
                AutoSize = true
            };

            var lblStatus = new Label
            {
                Text = $"Төлөв: {flight.Status}",
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Location = new Point(10, 35),
                AutoSize = true,
                ForeColor = Color.DarkGreen
            };

            flightPanel.Controls.Add(lblNumber);
            flightPanel.Controls.Add(lblStatus);

            // 👇 Click эвент — тухайн нислэгийн мэдээллийг tableLayout-д үзүүлнэ
            flightPanel.Click += (s, e) =>
            {
                tableLayoutPanel1.Visible = true;
            };

            FlightListFlowPanel.Controls.Add(flightPanel);
        }
    }



    private void Form1_Load(object sender, EventArgs e)
    {

        blazorWebView1.WebView.Source = new Uri(_hubUrl);
        //label_ConnectionStatus.Text = _hubConnection.State.ToString();
    }


    private void ChangeStateButton_Click(object sender, EventArgs e)
    {
        using(var stateChangeForm = new StateChangeForm())
        {
            stateChangeForm.ShowDialog();
        }
    }
}
