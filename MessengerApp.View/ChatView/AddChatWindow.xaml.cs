using MessengerApp.ViewModel;
using MessengerApp.ViewModel.ChatViewModel;
using System.Threading.Tasks;
using System.Windows;

namespace MessengerApp.View.ChatView
{
    /// <summary>
    /// Логика взаимодействия для AddChatWindow.xaml
    /// </summary>
    public partial class AddChatWindow : Window
    {
        public Context _context;
        AddChatViewModel addChatViewModel { get; set; }
        public AddChatWindow(Context context, Func<Task> LoadChatsAsync)
        {
            InitializeComponent();
            _context = context;
            addChatViewModel = new AddChatViewModel(_context, LoadChatsAsync);
            DataContext = addChatViewModel;
        }
    }
}
