using MessengerApp.Model;
using System.Net.Http;
using System.Net.Http.Json;

namespace MessengerApp.ViewModel.Utils
{
    public class ApiServiceMessage
    {
        private readonly HttpClient _httpClient;
        public ApiServiceMessage()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7259/messenger-api/")
            };
        }
        public async Task<MessagesInChat> AddMessageInChatAsync(Chat chat, Message message)
        {
            var msgInChat = (chat, message);
            var response = await _httpClient.PostAsJsonAsync("Messages/add-message-in-chat", msgInChat);

            if (response.IsSuccessStatusCode)
            {
                var returnMessage = await response.Content.ReadFromJsonAsync<MessagesInChat>();
                if (returnMessage == null)
                {
                    throw new Exception($"Не удалось получить данные!");
                }
                return returnMessage;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
        public async Task<List<MessagesInChat>> GetAllMessagesInChatAsync(Guid chatId)
        {
            var response = await _httpClient.GetAsync($"Messages/get-all-msg/{chatId}");

            if (response.IsSuccessStatusCode)
            {
                var messages = await response.Content.ReadFromJsonAsync<List<MessagesInChat>>();

                if(messages == null)
                {
                    return new List<MessagesInChat>();
                }
                return messages;
            }
            else
            {
                throw new Exception($"Error: {response.StatusCode}");
            }
        }
    }
}
