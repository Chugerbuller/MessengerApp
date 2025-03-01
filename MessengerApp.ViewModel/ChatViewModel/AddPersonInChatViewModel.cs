using MessengerApp.Model;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows;

namespace MessengerApp.ViewModel.ChatViewModel
{
    public class AddPersonInChatViewModel : ReactiveObject
    {
        public Context _context;
        [Reactive] public Guid PersonId { get; set; }
        Chat SelectedChat { get; set; }
        public ReactiveCommand<Window, bool> AddPersonInChatCommand { get; set; }
        public AddPersonInChatViewModel(Context context, Chat chat)
        {
            _context = context;
            SelectedChat = chat;
            AddPersonInChatCommand = ReactiveCommand.CreateFromTask<Window, bool>(AddPersonInChat);
        }

        public async Task<bool> AddPersonInChat(Window window)
        {
            try
            {
                if (PersonId == Guid.Empty)
                {
                    throw new Exception("Поле пустое. Заполните поле ввода!");
                }

                var newPersonInChat = await _context.serviceChats.AddPersonInChatAsync(SelectedChat.Id, PersonId);
                if(newPersonInChat == null)
                {
                    throw new Exception("Не удалось добавить пользователя в чат!");
                }
                MessageBox.Show("Пользователь успешно добавлен в чат!");
                window.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
