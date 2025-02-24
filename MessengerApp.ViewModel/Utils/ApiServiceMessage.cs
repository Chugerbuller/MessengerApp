using MessengerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ViewModel.Utils
{
    public class ApiServiceMessage
    {
        private readonly HttpClient _httpClient;
        public ApiServiceMessage()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7259/messenger")
            };
        }
        public async Task AddMessageInChatAsync(Chat chat, Message message)
        {
            var msgInChat = (chat, message);
            var response = await _httpClient.PostAsJsonAsync("messenger-api/messages/add-message-in-chat", msgInChat);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<MessagesInChat>();
                Console.WriteLine("Message added successfully.");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        public async Task GetAllMessagesInChatAsync(Guid chatId)
        {
            var response = await _httpClient.GetAsync($"messenger-api/messages/get-all-msg/{chatId}");

            if (response.IsSuccessStatusCode)
            {
                var messages = await response.Content.ReadFromJsonAsync<List<MessagesInChat>>();
                Console.WriteLine("Messages retrieved successfully.");
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}
