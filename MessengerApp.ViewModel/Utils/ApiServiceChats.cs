using MessengerApp.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace MessengerApp.ViewModel.Utils
{
    public class ApiServiceChats
    {
        private readonly HttpClient _httpClient;

        public ApiServiceChats()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7259/messenger-api/")
            };
        }
        public async Task<List<PersonsInChat>> GetAllUserChatsAsync(Guid userId)
        {
            var response = await _httpClient.GetAsync($"Chat/get-all-chats/{userId}");
            response.EnsureSuccessStatusCode();

            var personsInChats = await response.Content.ReadFromJsonAsync<List<PersonsInChat>>();
            if (personsInChats == null)
            {
                throw new Exception("Не удалось получить данные!");
            }
            return personsInChats;
        }
        public async Task<Chat> GetChatAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"Chat/get-chat/{id}");
            response.EnsureSuccessStatusCode();

            var chat = await response.Content.ReadFromJsonAsync<Chat>();
            if (chat == null)
            {
                throw new Exception("Не удалось получить данные!");
            }
            return chat;
        }
    }
}
