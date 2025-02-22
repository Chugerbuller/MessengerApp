using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.ViewModel.LoginAndRegistration
{
    public class RegistrationViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }


    }
}
