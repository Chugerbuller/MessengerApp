using MessengerApp.Model;
using MessengerApp.WebApi.Helpers;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Windows;

namespace MessengerApp.ViewModel.LoginAndRegistration
{
    public class RegistrationViewModel : ReactiveObject
    {
        [Reactive] public User User { get; set; }
        public Context _context;
        public RegistrationViewModel(Context context)
        {
            User = new User
            {
                Person = new Person()
            };
            _context = context;
        }

        public async Task<bool> Registration()
        {
            LoginAndPasswordValidation loginAndPasswordValidation = new LoginAndPasswordValidation();
            try
            {
                if (User.Login != null && User.Password != null && User.Person.FirstName != null && User.Person.LastName != null)
                {
                    if (loginAndPasswordValidation.CheckLogin(User.Login) == false)
                    {
                        throw new Exception("В логине недопустимые символы или длина логина меньше 5 символов." +
                            "Можно использовать только символы A-Z, цифры(0-9) и подчеркивание!");
                    }

                    if (loginAndPasswordValidation.CheckPassword(User.Password) == false)
                    {
                        throw new Exception("Длина пароля меньше 7 символов." +
                            "Пароль должен содержать хотя бы одну цифру, один символ в верхнем регистре и один символ в нижнем регистре");
                    }
                    bool IsCreatedSucсessfully = await _context.apiLAU.CreateUserAsync(User);
                    
                    if (IsCreatedSucсessfully)
                    {
                        MessageBox.Show("Регистрация прошла успешно!");
                        return true;
                    }
                }
                else
                {
                    throw new Exception("Одно или несколько полей пустые. Заполните поля!");
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка");
            }

            return false;
        }
    }
}
