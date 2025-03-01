using MessengerApp.Model;
using System;
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
                throw new InvalidOperationException("Не удалось получить список чатов!");
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
                throw new InvalidOperationException("Не удалось получить чат!");
            }
            return chat;
        }
        public async Task<Chat> AddChatAsync(Chat chat)
        {
            var response = await _httpClient.PostAsJsonAsync($"Chat/create-chat", chat);
            response.EnsureSuccessStatusCode();
            
            var newChat = await response.Content.ReadFromJsonAsync<Chat>();
            if (newChat == null)
            {
                throw new InvalidOperationException("Не удалось создать чат!");
            }
            return newChat;

        }
        public async Task<PersonsInChat> AddPersonInChatAsync(Guid chatId, Guid personId)
        {
            var response = await _httpClient.PostAsync($"Chat/add-person/{chatId}/{personId}", null);
            response.EnsureSuccessStatusCode();
            var newPersonInChat = await response.Content.ReadFromJsonAsync<PersonsInChat>();
            if(newPersonInChat == null)
            {
                throw new InvalidOperationException("Не удалось добавить пользователя в чат!");
            }
            return newPersonInChat;
        }

        public async Task<bool> DeletePersonInChatAsync(Guid chatId, Guid personId)
        {
            var response = await _httpClient.DeleteAsync($"Chat/delete-user-from-chat/{chatId}/{personId}");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new InvalidOperationException("Не удалось удалить пользователя!");
            }

        }
    }
}
