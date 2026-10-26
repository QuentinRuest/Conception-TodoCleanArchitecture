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
                goldCargo = ship.goldCargo,
                createdAt = ship.createdAt,
                captain = ship.captain,
                status = "sailing",
                crewSize = ship.crewSize,
                createdBy = ship.createdBy,
                lastModified = DateTime.UtcNow
            };
            var content = new StringContent(
                JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );
            var response = await _httpClient.PostAsync("sail", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
