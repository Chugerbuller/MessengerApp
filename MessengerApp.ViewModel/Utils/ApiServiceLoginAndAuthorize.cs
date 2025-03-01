using MessengerApp.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace MessengerApp.ViewModel.Utils
{
    public class ApiServiceLoginAndAuthorize
    {
        private readonly HttpClient _httpClient;
        public ApiServiceLoginAndAuthorize()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7259/messenger-api/")
            };
        }

        public async Task<User> AutorizeUserAsync(string login, string password)
        {
            HttpResponseMessage responce = await _httpClient.GetAsync($"User/authorize-user/{login}/{password}");
            
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

        public async Task<bool> CreateUserAsync(User newUser)
        {
            HttpResponseMessage responce = await _httpClient.PostAsJsonAsync("User/create-user/", newUser);
            if(responce.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new HttpRequestException("Не удалось создать пользователя!");
            }
        }
    }
}
