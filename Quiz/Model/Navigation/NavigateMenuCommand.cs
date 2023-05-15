using Quiz.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.ViewModel;
using System.Windows.Input;

namespace Quiz.Model.Navigation
{
    internal class NavigateMenuCommand : ICommand
    {
        private readonly NavigationStore _navStore;

        public NavigateMenuCommand(NavigationStore navStore)
        {
           _navStore = navStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _navStore.CurrentViewModel = new MenuViewModel(_navStore);
        }
    }
}
