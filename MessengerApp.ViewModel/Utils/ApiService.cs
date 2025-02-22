using MessengerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ViewModel.Utils
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("")
            };
        }

        public async Task<User> AutorizeUserAsync(string login, string password)
        {
            HttpResponseMessage responce = await _httpClient.GetAsync($"autorize-user/{login}/{password}");
            
            if(responce.IsSuccessStatusCode)
            { 
                return await responce.Content.ReadFromJsonAsync<User>();
            }
            else
            {
                throw new HttpRequestException(await responce.Content.ReadAsStringAsync());
            }
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            HttpResponseMessage responce = await _httpClient.PostAsJsonAsync($"create-user", newUser);
            if(responce.IsSuccessStatusCode)
            {
                return await responce.Content.ReadFromJsonAsync<User>();
            }
            else
            {
                throw new HttpRequestException(await responce.Content.ReadAsStringAsync());
            }
        }
    }
}
