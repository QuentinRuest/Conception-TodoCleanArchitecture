using CleanTodo.Domain.Interfaces.Gateway;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using CleanTodo.Domain.Entities;

namespace CleanTodo.Infrastructure.Gateway
{
    public class PirateBrokerGateway : IPirateBrokerGateway
    {
        private readonly HttpClient _httpClient;

        public PirateBrokerGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> GetAllPorts()
        {
            var response = await _httpClient.GetAsync("users");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            return json.GetProperty("users").Deserialize<List<string>>()
                ?? new List<string>();
        }
        public async Task Sail(Ship ship, string destination)
        {
            var payload = new
            {
                name = ship.name,
                captain = ship.captain,
                goldCargo = ship.goldCargo,
                crewSize = ship.crewSize,
                createdBy = ship.createdBy,
                createdAt = ship.createdAt,
                lastModified = DateTime.UtcNow,
                status = "sailing"
            };

            var path = $"ship/sail/{Uri.EscapeDataString(destination)}";

            var response = await _httpClient.PostAsJsonAsync(
                path,
                payload
            );

            response.EnsureSuccessStatusCode();
        }
    }
}
