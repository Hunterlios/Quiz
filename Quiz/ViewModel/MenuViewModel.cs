using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quiz.Model;
using Quiz.Model.Commands;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;


namespace Quiz.ViewModel
{
    internal class MenuViewModel : BaseViewModel
    {
        public ICommand NavigateToNewGameCommand { get; }
        public ICommand NavigateToCreateCommand { get; }
        public ICommand ShutDownCommand { get; }

        public MenuViewModel(NavigationStore navStore)
        {
            NavigateToNewGameCommand =  new NavigateToNewGameCommand(navStore);
            NavigateToCreateCommand = new NavigateToCreateCommand(navStore);
            ShutDownCommand = new ShutDownCommand();
        }


    }
}
