using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace FlightStatusHub
{
    public class FlightStatusHub : Hub
    {
        /// <summary>
        /// Sends flight status to all connected clients.
        /// </summary>
        public async Task SendFlightStatus(string flightNumber, string status)
        {
            Console.WriteLine($"[Hub] Flight {flightNumber} status: {status}");
            await Clients.All.SendAsync("ReceiveFlightStatus", flightNumber, status);
        }

        /// <summary>
        /// Sends a welcome message to the newly connected client.
        /// </summary>
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ReceiveMessage", "System", "✅ Connected to Flight Status Hub");
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// Optional: You can override OnDisconnectedAsync for logging or cleanup
        /// </summary>
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"[Hub] Client disconnected: {Context.ConnectionId}");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
