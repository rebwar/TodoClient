using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TodoClient.Models;

namespace TodoClient.Services
{
    public class TodoDataService : ITodoDataService
    {
        private readonly HttpClient _httpClient;

        public TodoDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ItemData>> GetAllItems()
        {
            var apiResponse=await _httpClient.GetStreamAsync("api/todo");
            return await JsonSerializer.DeserializeAsync<IEnumerable<ItemData>>
                    (apiResponse,new JsonSerializerOptions(){PropertyNameCaseInsensitive=true});
        }

        public async Task<ItemData> GetItemDetail(int id)
        {
            var apiResponse=await _httpClient.GetStreamAsync($"api/todo/{id}");
            return await JsonSerializer.DeserializeAsync<ItemData>
            (apiResponse,new JsonSerializerOptions(){PropertyNameCaseInsensitive=true});
        }
    }
}