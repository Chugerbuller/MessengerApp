using MessengerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ViewModel.Utils
{
    public class ApiServiceLoginAndAuthorize
    {
        private readonly HttpClient _httpClient;
        public ApiServiceLoginAndAuthorize()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7259/messenger")
            };
        }

        public async Task<User> AutorizeUserAsync(string login, string password)
        {
            HttpResponseMessage responce = await _httpClient.GetAsync($"autorize-user/{login}/{password}");
            
            if(responce.IsSuccessStatusCode)
            {
                var user = await responce.Content.ReadFromJsonAsync<User>();
                if(user == null)
                {
                    throw new Exception("Не удалось авторизоваться!");
                }
                return user;
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
                var user = await responce.Content.ReadFromJsonAsync<User>();
                if (user == null)
                {
                    throw new Exception("Не удалось зарегистрироваться!");
                }
                return user;
            }
            else
            {
                throw new HttpRequestException(await responce.Content.ReadAsStringAsync());
            }
        }
    }
}
