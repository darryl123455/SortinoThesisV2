using System.Net.Http.Json;
using SortinoThesisV2.Shared.Models;

namespace SortinoThesisV2.Client.Services
{
    public class PointsService
    {
        private readonly HttpClient _httpClient;

        public PointsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all points
        public async Task<List<PointsModel>> GetPointsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<PointsModel>>("api/Points");
        }

        // Get a specific point by ID
        public async Task<PointsModel> GetPointByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PointsModel>($"api/Points/{id}");
        }

        // Add a new point
        public async Task AddPointAsync(PointsModel point)
        {
            await _httpClient.PostAsJsonAsync("api/Points", point);
        }

        // Update a point
        public async Task UpdatePointAsync(int id, PointsModel point)
        {
            await _httpClient.PutAsJsonAsync($"api/Points/{id}", point);
        }

        // Delete a point
        public async Task DeletePointAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Points/{id}");
        }
    }
}
