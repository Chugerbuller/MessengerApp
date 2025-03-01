using MessengerApp.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows;

namespace MessengerApp.ViewModel.ChatViewModel
{
    public class AddChatViewModel : ReactiveObject
    {
        public Context _context;
        [Reactive]public string chatName { get; set; }
        Func<Task> LoadChats { get; set; }
        public ReactiveCommand<Window, bool> AddChatCommand { get; set; }
        public AddChatViewModel(Context context, Func<Task> LoadChatsAsync)
        {
            _context = context;
            LoadChats = LoadChatsAsync;
            AddChatCommand = ReactiveCommand.CreateFromTask<Window, bool>(AddChat);
        }
        public async Task<bool> AddChat(Window window)
        {
            try
            {
                if (chatName == null)
                {
                    throw new Exception("Поле пустое. Заполните поле ввода!");
                }

                var newchat = await _context.serviceChats.AddChatAsync(new Chat { ChatName = chatName });
                await _context.serviceChats.AddPersonInChatAsync(newchat.Id, _context.AuthorizedUser.PersonID);
                await Task.Run(LoadChats);
                window.Close();
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
