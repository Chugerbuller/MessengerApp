using MessengerApp.Model;
using MessengerApp.WebApi.Helpers;
using ReactiveUI;
using System.Reactive;
using System.Windows;

namespace MessengerApp.ViewModel.LoginAndRegistration
{
    public class RegistrationViewModel : ReactiveObject
    {
        LoginAndPasswordValidation loginAndPasswordValidation = new LoginAndPasswordValidation();
        public User User { get; set; }
        public Context _context;
        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public RegistrationViewModel(Context context)
        {
            User = new User
            {
                Person = new Person()
            };
            _context = context;
            RegisterCommand = ReactiveCommand.CreateFromTask(Registration);
        }

        public async Task Registration()
        {
            try
            {
                /*if (User.Login != null && User.Password != null && User.Person.FirstName != null && User.Person.LastName!= null )*/
                //{ 
                    if (loginAndPasswordValidation.CheckLogin(User.Login) == false)
                    {
                        throw new Exception("В логине недопустимые символы или длина логина меньше 5 символов." +
                            "Можно использовать только символы A-Z, цифры(0-9) и подчеркивание!");
                    }

                    if (loginAndPasswordValidation.CheckPassword(User.Password) == false)
                    {
                        throw new Exception("Длина пароля меньше 7 символов или в пароле присутствуют недопустимые символы." +
                            "Можно использовать только цифры(0-9) и символы( ! @ # $ % ^ & * ( ) _ )!");
                    }
                    var newUser = await _context.apiLAU.CreateUserAsync(User);
                    
                    if (newUser != null)
                    {
                        _context.AutorizedUser = newUser;
                    }
                //}
               /* else
                {
                    throw new Exception("Одно или несколько полей пустые. Заполните поля!");
                }*/
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }
        }
    }
}
