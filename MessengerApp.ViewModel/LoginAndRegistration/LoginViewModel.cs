using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ViewModel.LoginAndRegistration
{
    public class LoginViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> LoginCommand { get;}

        public LoginViewModel()
        {
            LoginCommand = ReactiveCommand.CreateFromTask(Login);
        }

        private async Task Login()
        {
           

        }





    }
}
