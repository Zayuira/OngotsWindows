using System;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using FlightLibrary.DTO;
using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormsApp31
{
    public partial class StateChangeForm : Form
    {
        public StateChangeForm()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // SignalR-ээр биш, API-ээр шинэчилнэ!
            int flightId = int.Parse(textBox_FlightNumber.Text);
            string status = comboBox_Status.SelectedItem?.ToString() ?? "Тодорхойгүй";

            var req = new UpdateFlightStatusRequest
            {
                FlightId = flightId,
                NewStatus = status
            };
            string apiUrl = "http://localhost:5000/api/flightinfo/status";

            using var client = new HttpClient();
            var json = JsonSerializer.Serialize(req);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Төлөв амжилттай шинэчлэгдлээ.");
            }
            else
            {
                MessageBox.Show("Шинэчлэхэд алдаа гарлаа: " + await response.Content.ReadAsStringAsync());
            }
        }

        private void StateChangeForm_Load(object sender, EventArgs e)
        {
            comboBox_Status.Items.Clear();
            comboBox_Status.Items.Add("Registering");
            comboBox_Status.Items.Add("Boarding");
            comboBox_Status.Items.Add("Departed");
            comboBox_Status.Items.Add("Delayed");
            comboBox_Status.Items.Add("Cancelled");
            comboBox_Status.SelectedIndex = 0;

        }
    }
}
