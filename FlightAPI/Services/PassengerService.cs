﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FlightLibrary.DTO;
namespace FlightAPI.Services
{
    public class PassengerService
    {
        private readonly HttpClient _client;

        public PassengerService()
        {
            _client = new HttpClient { BaseAddress = new Uri("https://localhost:5001/api/") };
        }

        public async Task<PassengerDto?> GetPassengerAsync(string passport)
        {
            var res = await _client.GetAsync($"Passenger/{passport}");
            if (res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<PassengerDto>(
                    await res.Content.ReadAsStringAsync());
            }
            return null;
        }

        public async Task<bool> AssignSeatAsync(PassengerDto dto)
        {
            var res = await _client.PostAsJsonAsync("Passenger/assign-seat", dto);
            return res.IsSuccessStatusCode;
        }
    }
}
