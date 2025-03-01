using MessengerApp.ViewModel.ChatViewModel;
using MessengerApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessengerApp.Model;

namespace MessengerApp.View.ChatView
{
    /// <summary>
    /// Логика взаимодействия для AddPersonInChatWindow.xaml
    /// </summary>
    public partial class AddPersonInChatWindow : Window
    {
        public Context _context;
        AddPersonInChatViewModel addPersonInChat { get; set; }
        public AddPersonInChatWindow(Context context, Chat chat)
        {
            InitializeComponent();
            _context = context;
            addPersonInChat = new AddPersonInChatViewModel(_context, chat);
            DataContext = addPersonInChat;
        }
    }
}
