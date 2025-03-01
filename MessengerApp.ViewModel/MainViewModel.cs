using MessengerApp.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Windows;
using System.Windows.Threading;

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
            Messages = new ObservableCollection<MessagesInChat>();
            LoadChatsAsync();

            this.WhenAnyValue(x => x.selectedChat)
               .Subscribe(async chat =>
               {
                   if(selectedChat != null)
                   { 
                       if (Messages != null)
                       {
                       Messages.Clear();
                       }

                       if (chat != null)
                       {
                           await _context.serviceHubMessage.EnterInChat(_context.AuthorizedUser.PersonID);
                           _context.serviceHubMessage.SubscribeOnMessages(ReceiveMessage);
                           await GetAllMessagesInChat();
                       }
                       else
                       {
                           await _context.serviceHubMessage.Disconnection();
                       }
                   }

               });

            AddMessageInChatCommand = ReactiveCommand.CreateFromTask(AddMessageInChat);
        }

        //<Chats>
        public async Task LoadChatsAsync()
        {
            try
            {
                if (_context.AuthorizedUser != null)
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
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public async Task RefreshChats()
        {
            await Application.Current.Dispatcher.Invoke(async () => 
            {
                selectedChat = null;
                await LoadChatsAsync();
            });
            
        }
        //</Chats>


        //<Message>
        private async Task AddMessageInChat()
        {
            /*  try
              {
                  await _context.serviceMessage.AddMessageInChatAsync(selectedChat, new Model.Message
                  {
                      MessageContent = Message,
                      PersonId = _context.AuthorizedUser.PersonID
                  });

                  MessageBox.Show("Сообщение отправлено успешно!");
              } catch (Exception e)
              {
                  MessageBox.Show(e.Message, "error");
              }
            */
            if(selectedChat != null)
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
                        Message = new Message
                        {
                            MessageContent = Message,
                            PersonId = _context.AuthorizedUser.PersonID,
                        }
                    };

                    await _context.serviceHubMessage.SendMessage(NewMessage);
                    Message = null;

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
        public async Task GetAllMessagesInChat()
        {
            try
            {
                var messagesInChat = await _context.serviceMessage.GetAllMessagesInChatAsync(selectedChat.Id);
                if (messagesInChat == null)
                {
                    throw new Exception("Не удалось получить список сообщений!");
                }

                foreach (var item in messagesInChat)
                {
                    Messages.Add(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }    
        }
        public void ReceiveMessage(MessagesInChat message)
        {
            Application.Current.Dispatcher.Invoke(() => Messages.Add(message));
        }
        //</Message>  


    }
}
