using System.Windows;
using MessengerApp.ViewModel;
using MessengerApp.View.ChatView;
using System.Windows.Input;

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
        if(_context.AuthorizedUser == null)
        {
            AddChatWindow addChatWindow = new AddChatWindow(_context, mainViewModel.RefreshChats);
            addChatWindow.ShowDialog();
        }
    }
    private void AddPersonInChat_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            if (mainViewModel.selectedChat == null)
            {
                throw new Exception("Чат не выбран! Выберите чат в который нужно добавить пользователя!");
            }
            AddPersonInChatWindow addPersonInChatWindow = new AddPersonInChatWindow(_context, mainViewModel.selectedChat);
            addPersonInChatWindow.ShowDialog();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}