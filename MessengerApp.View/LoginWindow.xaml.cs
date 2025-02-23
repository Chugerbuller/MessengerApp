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
        public LoginWindow(Context context)
        {
            InitializeComponent();
            _context = context;
            DataContext = new LoginViewModel(_context);
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow(_context);
            this.Close();
            registrationWindow.ShowDialog();

            if (registrationWindow.DialogResult == true)
            {
                MainWindow mainWindow = new MainWindow(_context);
                mainWindow.Show();
            }
        }
        void PasswordChangedHandler(Object sender, RoutedEventArgs args)
        {
            _context.AutorizedUser.Password = ((PasswordBox)sender).Password;
        }

    }
}
