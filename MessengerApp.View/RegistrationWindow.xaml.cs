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
            _context = context;
            registrationViewModel = new RegistrationViewModel(_context);
            DataContext = registrationViewModel;
            InitializeComponent();
        }     
        public void EnterRegistration(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(async () => {
               var result = await registrationViewModel.Registration();
               if(result == true)
               {
                    LoginWindow loginWindow = new LoginWindow(_context);
                    this.Close();
                    loginWindow.Show();
               }
            });
        }
        private void RegisterPasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            registrationViewModel.User.Password = ((PasswordBox)sender).Password;
        }
    }
}
