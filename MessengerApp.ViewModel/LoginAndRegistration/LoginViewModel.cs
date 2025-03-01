using MessengerApp.Model;
using MessengerApp.WebApi.Helpers;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows;

namespace MessengerApp.ViewModel.LoginAndRegistration
{
    public class LoginViewModel : ReactiveObject
    {
        [Reactive] public string login { get; set; }
        [Reactive] public string password { get; set; }
        public Context _context;

        public LoginViewModel(Context context)
        {
            _context = context;
        }      
        public async Task<bool> Login()
        {
            try
            {
                LoginAndPasswordValidation loginAndPasswordValidation = new LoginAndPasswordValidation();
                if (login != null && password != null)
                {
                    if (loginAndPasswordValidation.CheckLogin(login) == false)
                    {
                        throw new Exception("В логине недопустимые символы или длина логина меньше 5 символов." +
                            "Можно использовать только символы A-Z, цифры(0-9) и подчеркивание!");
                    }

                    if (loginAndPasswordValidation.CheckPassword(password) == false)
                    {
                        throw new Exception("Длина пароля меньше 7 символов." +
                            "Пароль должен содержать хотя бы одну цифру, один символ в верхнем регистре и один символ в нижнем регистре");
                    }
                    User user = await _context.apiLAU.AutorizeUserAsync(login, password);
                    _context.AuthorizedUser = user;
                    return true; 
                }
                else
                {
                    throw new Exception("Одно или несколько полей пустые. Заполните поля!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return false;
        }
    }
}
