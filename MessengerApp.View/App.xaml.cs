using System.Configuration;
using System.Data;
using System.Windows;

namespace MessengerApp.View;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        LoginWindow loginWindow = new LoginWindow();
        loginWindow.ShowDialog();

        if (loginWindow.DialogResult == true)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

