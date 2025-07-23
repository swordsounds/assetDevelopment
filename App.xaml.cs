using assetDevelopment.Models;
using assetDevelopment.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace assetDevelopment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
            // Initialize application resources or services here if needed
        }
    }

}
