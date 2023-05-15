using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz.Model.Navigation
{
    internal class NavigateToCreateCommand : ICommand
    {
        private readonly NavigationStore _navStore;

        public NavigateToCreateCommand(NavigationStore navStore)
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
            _navStore.CurrentViewModel = new CreateViewModel(_navStore);
        }
    }
}
