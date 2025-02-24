using System.Windows;
using System.Windows.Controls;
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
        RegistrationViewModel registrationViewModel;
        public RegistrationWindow(Context context)
        {
            InitializeComponent();
            _context = context;
            registrationViewModel = new RegistrationViewModel(_context);
            DataContext = registrationViewModel;
        }
        private void RegisterPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            registrationViewModel.User.Password = ((PasswordBox)sender).Password;
        }
    }
}
