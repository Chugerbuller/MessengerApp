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
        public Context _context;
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public RegistrationViewModel(Context context)
        {
            _context = context;
            RegisterCommand = ReactiveCommand.CreateFromTask(Registration);
        }

        private async Task Registration()
        {

        }
    }
}
