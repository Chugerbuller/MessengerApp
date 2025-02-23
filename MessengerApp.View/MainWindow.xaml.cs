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
}