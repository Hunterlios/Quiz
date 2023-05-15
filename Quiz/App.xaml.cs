using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Quiz.ViewModel;
using Quiz.View;
using Quiz.Model;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navStore = new NavigationStore();

            navStore.CurrentViewModel = new CreateViewModel(navStore);

            MainWindow = new MainWindowView()
            {
                DataContext = new MainViewModel(navStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

    }
}
