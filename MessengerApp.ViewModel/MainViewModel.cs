using DynamicData;
using DynamicData.Binding;
using MessengerApp.Model;
using NuGet.Protocol.Plugins;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive;
using System.Windows;

namespace MessengerApp.ViewModel
{
    public class MainViewModel : ReactiveObject
    {
        [Reactive] public User User { get; set; }
        [Reactive] public string Message { get; set; }
        [Reactive] public Chat? selectedChat { get; set; }

        public Context _context;
        public ObservableCollection<Chat> Chats { get; set; }
        public ObservableCollection<MessagesInChat> Messages { get; set; }
        public ReactiveCommand<Unit, Unit> AddMessageInChatCommand { get; }
        public MainViewModel(Context context)
        {
            _context = context;
            User = _context.AuthorizedUser;
            Chats = new ObservableCollection<Chat>();
            LoadChatsAsync();

            this.WhenAnyValue(x => x.selectedChat)
               .Subscribe(async chat =>
               {
                   if (chat != null)
                   {
                       await _context.serviceHubMessage.EnterInChat(chat.Id);
                       _context.serviceHubMessage.SubscribeOnMessages(ReceiveMessage);
                       await GetAllMessagesInChat();
                   }
                   else
                   {
                       if(Messages != null)
                       { 
                           Messages.Clear();
                       }
                       await _context.serviceHubMessage.Disconnection();
                   }
               });

            AddMessageInChatCommand = ReactiveCommand.CreateFromTask(AddMessageInChat);
        }
        //<Chats>
        private async Task LoadChatsAsync()
        {
            if(_context.AuthorizedUser != null)
            {  
                var userId = _context.AuthorizedUser.Id;
                var personInChats = await _context.serviceChats.GetAllUserChatsAsync(userId);

                Chats.Clear();
                foreach (var personInChat in personInChats)
                {
                    var chat = await _context.serviceChats.GetChatAsync(personInChat.ChatId);
                    if (chat != null)
                    {
                        Chats.Add(chat);
                    }
                }
            }
        }
        //</Chats>


        //<Message>
        private async Task AddMessageInChat()
        {
            try
            {
                if (Message == null)
                {
                    throw new Exception("Сообщение пустое!");
                }

                MessagesInChat NewMessage = new MessagesInChat
                {
                    ChatId = selectedChat.Id,
                    Message = new Model.Message
                    {
                        MessageContent = Message,
                        PersonId = _context.AuthorizedUser.PersonID
                    }
                };

                await _context.serviceHubMessage.SendMessage(NewMessage);
                // Messages.Add(NewMessage);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private async Task GetAllMessagesInChat()
        {
            try
            {
                var messagesInChat = await _context.serviceMessage.GetAllMessagesInChatAsync(selectedChat.Id);
                if (messagesInChat == null)
                {
                    throw new Exception("Не удалось получить список сообщений!");
                }

                Messages = new ObservableCollection<MessagesInChat>(messagesInChat);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }    
        }

        //</Message>

        public void ReceiveMessage(MessagesInChat message)
        {
            Messages.Add(message);
        }
    }
}
