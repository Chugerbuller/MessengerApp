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
        public async Task EnterInChat(Guid Id)
        {
            if(client.State != HubConnectionState.Connected)
            {
                await client.StartAsync();
            }

            await client.InvokeAsync("EnterInMessenger", Id);
        }
        public async Task Disconnection()
        {
            await client.StopAsync();
        }
        public void SubscribeOnMessages(ReceiveMessage receiveMessage)
        {
            client.On<MessagesInChat>("ReciveMsg", (msg) =>
            {
                  receiveMessage(msg);
            });
        }

        public async Task SendMessage(MessagesInChat msgInChat)
        {
            await client.InvokeAsync("SendMsg", msgInChat);
        }
    }
}
