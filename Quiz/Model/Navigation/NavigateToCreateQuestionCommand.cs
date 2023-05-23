using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Quiz.Model
{
    internal class NavigateToCreateQuestionCommand : ICommand
    {
        private readonly NavigationStore _navStore;
        private readonly CreateNameViewModel _viewModel;
        public NavigateToCreateQuestionCommand(NavigationStore navStore, CreateNameViewModel createNameViewModel)
        {
            _navStore = navStore;
            _viewModel = createNameViewModel;   
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (string.IsNullOrEmpty(_viewModel.Name))
            {
                MessageBox.Show("Nazwa Quizu nie może być pusta");
            }
            else
            {
                _navStore.CurrentViewModel = new CreateQuestionViewModel(_navStore, _viewModel);
            }
        }
    }
}
