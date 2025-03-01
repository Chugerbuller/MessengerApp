using MessengerApp.Model;
using Microsoft.AspNetCore.SignalR.Client;

namespace MessengerApp.ViewModel.Utils
{
    public class ApiServiceHubMesseges
    {
        private readonly HubConnection client;
        
        public ApiServiceHubMesseges()
        {
            client = new HubConnectionBuilder()
                        .WithUrl("https://localhost:7259/messenger/")
                        .Build();
            
        }
        public async Task EnterInChat(Guid personId)
        {
            if(client.State != HubConnectionState.Connected)
            {
                await client.StartAsync();
            }

            await client.InvokeAsync("EnterInMessenger", personId);
        }
        public async Task Disconnection()
        {
            await client.StopAsync();
        }
        public void SubscribeOnMessages(Action<MessagesInChat> receiveMessage)
        {
            client.On<MessagesInChat>("ReciveMsg", receiveMessage);
        }

        public async Task SendMessage(MessagesInChat msgInChat)
        {
            await client.InvokeAsync("SendMsg", msgInChat);
        }
    }
}
