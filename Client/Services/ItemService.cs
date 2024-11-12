using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SortinoThesisV2.Shared.Models;

namespace SortinoThesisV2.Client.Services
{
    public class ItemService
    {
        private readonly HttpClient _httpClient;

        public ItemService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get all items
        public async Task<List<ItemModel>> GetItemsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ItemModel>>("api/items");
        }

        // Get a single item by id
        public async Task<ItemModel> GetItemAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ItemModel>($"api/items/{id}");
        }

        // Add a new item
        public async Task AddItemAsync(ItemModel item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/items", item);
            if (!response.IsSuccessStatusCode)
            {
                // Handle error (log it, show a message, etc.)
            }
        }

        // Update an existing item
        public async Task UpdateItemAsync(int id, ItemModel item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/items/{id}", item);
            if (!response.IsSuccessStatusCode)
            {
                // Handle error
            }
        }

        // Delete an item
        public async Task DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/items/{id}");
            if (!response.IsSuccessStatusCode)
            {
                // Handle error
            }
        }
    }
}
