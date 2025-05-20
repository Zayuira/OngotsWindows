using System;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormsApp31
{
    public partial class StateChangeForm : Form
    {
        private readonly string _defaultHubUrl = "http://localhost:5000/flightstatushub";
        private HubConnection _hubConnection;

        public StateChangeForm()
        {
            InitializeComponent();
        }

        private async Task ConnectToHub()
        {
            string hubUrl = string.IsNullOrWhiteSpace(textBox_HubURL.Text)
                ? _defaultHubUrl
                : textBox_HubURL.Text;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(new Uri(hubUrl))
                .WithAutomaticReconnect()
                .Build();

            label_ConnectionStatus.Text = "Connecting...";
            try
            {
                await _hubConnection.StartAsync();
                label_ConnectionStatus.Text = $"Connected ({_hubConnection.State})";
            }
            catch (Exception ex)
            {
                label_ConnectionStatus.Text = "Connection failed";
                MessageBox.Show($"Холболт амжилтгүй боллоо: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _hubConnection.Reconnected += connectionId =>
            {
                label_ConnectionStatus.Invoke(() => label_ConnectionStatus.Text = "Reconnected");
                return Task.CompletedTask;
            };

            _hubConnection.Reconnecting += exception =>
            {
                label_ConnectionStatus.Invoke(() => label_ConnectionStatus.Text = "Reconnecting...");
                return Task.CompletedTask;
            };

            _hubConnection.Closed += exception =>
            {
                label_ConnectionStatus.Invoke(() => label_ConnectionStatus.Text = "Disconnected");
                return Task.CompletedTask;
            };
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            await ConnectToHub();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (_hubConnection == null || _hubConnection.State != HubConnectionState.Connected)
            {
                MessageBox.Show("Hub-д холбогдоогүй байна!", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string flightNumber = textBox_FlightNumber.Text;
            string status = comboBox_Status.SelectedItem?.ToString() ?? "Тодорхойгүй";

            try
            {
                await _hubConnection.InvokeAsync("SendFlightStatus", flightNumber, status);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Мэдээлэл илгээхэд алдаа гарлаа: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StateChangeForm_Load(object sender, EventArgs e)
        {
            comboBox_Status.Items.Clear();
            comboBox_Status.Items.Add("Бүртгэж байна");
            comboBox_Status.Items.Add("Онгоцонд сууж байна");
            comboBox_Status.Items.Add("Ниссэн");
            comboBox_Status.Items.Add("Хойшилсон");
            comboBox_Status.Items.Add("Цуцалсан");
            comboBox_Status.SelectedIndex = 0;

            textBox_HubURL.Text = _defaultHubUrl;
        }
    }
}
