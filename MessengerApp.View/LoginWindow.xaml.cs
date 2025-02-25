using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MessengerApp.ViewModel;
using MessengerApp.ViewModel.LoginAndRegistration;
namespace MessengerApp.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public Context _context;
        public LoginViewModel loginViewModel;
        public LoginWindow(Context context)
        {
            InitializeComponent();
            _context = context;
            loginViewModel = new LoginViewModel(_context);
            DataContext = loginViewModel;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(_context);
            this.Close();
            registrationWindow.Show();
        }

        public void EnterLogin(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(async () => {
                var result = await loginViewModel.Login();
                if (result == true)
                {
                    MainWindow mainWindow = new MainWindow(_context);
                    this.Close();
                    mainWindow.Show();
                }
            });
        }
        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            loginViewModel.password = ((PasswordBox)sender).Password;
        }

    }
}
