using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Quiz.Model.Navigation
{
    internal class NavigateToCreateNameCommand : ICommand
    {
        private readonly NavigationStore _navStore;

        CreateQuestionViewModel _createViewModel;

        public NavigateToCreateNameCommand(NavigationStore navStore, CreateQuestionViewModel viewModel)
        {
            _createViewModel = viewModel;
            _navStore = navStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_createViewModel==null || _createViewModel.goBack )
            _navStore.CurrentViewModel = new CreateNameViewModel(_navStore);
            else
            {
                _createViewModel.goBack = !_createViewModel.goBack;
                MessageBox.Show("Wszystkie niezapisane zmiany zostaną utracone! Jeśli mimo wszystko chcesz wyjść, kliknij jeszcze raz");
            }
        }
    }
}
