using System.Configuration;
using System.Data;
using System.Windows;
using MessengerApp.ViewModel;

namespace MessengerApp.View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public Context context = new Context();
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        LoginWindow loginWindow = new LoginWindow(context);
        loginWindow.Show();
    }
}

