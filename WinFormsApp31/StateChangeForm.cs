using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;

namespace WinFormsApp31;

public partial class StateChangeForm : Form
{
    private readonly string _url = "http://localhost:5000/flightstatushub";
    private readonly string _hubUrl = "https://localhost:7227/flightstatusdisplay";
    HubConnection _hubConnection;
    public StateChangeForm()
    {
        InitializeComponent();
    }
    private async Task ConnectToHub()
    {
        // Create a new HubConnection
        _hubConnection = new HubConnectionBuilder()
        .WithUrl(new Uri(textBox_HubURL.Text ?? _url))
        .WithAutomaticReconnect()
        .Build();

        label_ConnectionStatus.Text = "Connecting...";
        await _hubConnection.StartAsync();
        label_ConnectionStatus.Text = _hubConnection.State.ToString();
        _hubConnection.Reconnected += async (connectionId) =>
        {
            label_ConnectionStatus.Text = "Reconnected to the server";
        };

        _hubConnection.Reconnecting += async (exception) =>
        {
            label_ConnectionStatus.Text = "Reconnecting to the server...";
        };

        _hubConnection.Closed += async (exception) =>
        {
            label_ConnectionStatus.Text = "Disconnected from the server";
        };


    }
    private async void button3_Click(object sender, EventArgs e)
    {
        await ConnectToHub();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _hubConnection.InvokeAsync("SendFlightStatus", textBox_FlightNumber.Text, textBox_Status.Text);
    }
}
