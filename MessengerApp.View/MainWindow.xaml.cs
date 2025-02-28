using System.Windows;
using MessengerApp.ViewModel;

namespace MessengerApp.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Context _context;
    public MainWindow(Context context)
    {
        InitializeComponent();
        _context = context;
        DataContext = new MainViewModel(_context);
    }
    public void LogOut(object sender, RoutedEventArgs e)
    {
        _context.AuthorizedUser = null;
        LoginWindow login = new LoginWindow(_context);
        this.Close();
        login.Show();
    }
}