using MessengerApp.Model;
using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace MessengerApp.ViewModel.LoginAndRegistration
{
    public class LoginViewModel : ReactiveObject
    {
        public string login { get; set; }
        public string password { get; set; }
        public Context _context;
        public ReactiveCommand<Unit, Unit> LoginCommand { get;}

        public LoginViewModel(Context context)
        {
            _context = context;
            LoginCommand = ReactiveCommand.CreateFromTask(Login);
        }

        private async Task Login()
        {
            try
            {
                User user = await _context.apiLAU.AutorizeUserAsync(login, password);
                _context.AutorizedUser = user;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }






    }
}
