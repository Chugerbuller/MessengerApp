using System.Windows;
using MessengerApp.ViewModel;
using MessengerApp.View.ChatView;
using System.Windows.Input;
using System.Threading.Tasks;

namespace MessengerApp.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Context _context;
    public MainViewModel mainViewModel { get; set; }
    public MainWindow(Context context)
    {
        InitializeComponent();
        _context = context;
        mainViewModel = new MainViewModel(_context);
        DataContext = mainViewModel;
    }
    public void LogOut(object sender, RoutedEventArgs e)
    {
        _context.AuthorizedUser = null;
        LoginWindow login = new LoginWindow(_context);
        this.Close();
        login.Show();
    }
    private void ProfileTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
    {
        ProfileWindow profileWindow = new ProfileWindow(_context);
        profileWindow.ShowDialog();
    }
    private void AddChats_Click(object sender, RoutedEventArgs e)
    {
        if(_context.AuthorizedUser != null)
        {
            AddChatWindow addChatWindow = new AddChatWindow(_context, mainViewModel.RefreshChats);
            addChatWindow.ShowDialog();
        }
    }
    private void AddPersonInChat_Click(object sender, RoutedEventArgs e)
    {

        if (mainViewModel.selectedChat != null)
        {
            AddPersonInChatWindow addPersonInChatWindow = new AddPersonInChatWindow(_context, mainViewModel.selectedChat);
            addPersonInChatWindow.ShowDialog();
        }
        else
        {
            MessageBox.Show("Поле пустое! Введите Person Id!");
        }
    }
    private async void LogOutInChat_Click(object sender, RoutedEventArgs e)
    {
        if (mainViewModel.selectedChat != null)
        {
            var rezult = await _context.serviceChats.DeletePersonInChatAsync(mainViewModel.selectedChat.Id, _context.AuthorizedUser.PersonID);
            MessageBox.Show("Пользователь успешно вышел из чата!");
            await mainViewModel.LoadChatsAsync();

            if (rezult == false)
            {
                MessageBox.Show("Не удалось выйти из чата!");
            }
        }
        else
        {
            MessageBox.Show("Чат не выбран! Выберите чат из которого хотите выйти!");
        }
    }
}