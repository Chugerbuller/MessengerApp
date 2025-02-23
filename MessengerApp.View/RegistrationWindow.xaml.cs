using System.Windows;
using MessengerApp.ViewModel;
using MessengerApp.ViewModel.LoginAndRegistration;

namespace MessengerApp.View
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public Context _context;
        public RegistrationWindow(Context context)
        {
            InitializeComponent();
            _context = context;
            DataContext = new RegistrationViewModel(_context);
        }
    }
}
