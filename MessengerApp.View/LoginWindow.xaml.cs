using System.Windows;
using System.Windows.Input;
using MessengerApp.ViewModel.LoginAndRegistration;
namespace MessengerApp.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            this.Close();
            registrationWindow.ShowDialog();
        }
    }
}
