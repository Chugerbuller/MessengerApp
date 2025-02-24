using MessengerApp.Model;
using NuGet.Protocol.Plugins;
using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace MessengerApp.ViewModel
{
    public class MainViewModel
    {
        public MessagesInChat message { get; set; }
        public Context _context;
        public ReactiveCommand<Unit, Unit> AddMessageInChatCommand { get; }
        public ReactiveCommand<Unit, Unit> GetAllMessagesInChatCommand { get; }
        public MainViewModel(Context context)
        {
            _context = context;
            message = new MessagesInChat
            {
                ChatId = new Guid(),
                MessageId = new Guid()
            };
            AddMessageInChatCommand = ReactiveCommand.CreateFromTask(AddMessageInChat);
            GetAllMessagesInChatCommand = ReactiveCommand.CreateFromTask(GetAllMessagesInChat);
        }
        private async Task AddMessageInChat()
        {
            try
            {
                if (message.Message.MessageContent == null)
                {
                    throw new Exception("Сообщение пустое!");
                }
                await _context.serviceMessage.AddMessageInChatAsync(new Chat { Id = message.ChatId, ChatName = "Chat Name" },
                    new Model.Message { MessageContent = message.Message.MessageContent });
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private async Task GetAllMessagesInChat()
        {
            await _context.serviceMessage.GetAllMessagesInChatAsync(message.ChatId);
        }

    }
}
