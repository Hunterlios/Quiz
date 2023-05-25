using Quiz.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.ViewModel;
using System.Windows.Input;
using System.Windows;

namespace Quiz.Model.Navigation
{
    internal class NavigateMenuCommand : ICommand
    {
        private readonly NavigationStore _navStore;
        CreateQuestionViewModel _createQuestionViewModel;
        public NavigateMenuCommand(NavigationStore navStore)
        {
           _navStore = navStore;
        }
        public NavigateMenuCommand(NavigationStore navStore, CreateQuestionViewModel createQuestionViewModel)
        {
            _createQuestionViewModel = createQuestionViewModel;
            _navStore = navStore;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_createQuestionViewModel!=null && !_createQuestionViewModel.goBack)
            {
                _createQuestionViewModel.goBack = !_createQuestionViewModel.goBack;
                MessageBox.Show("Wszystkie niezapisane zmiany zostaną utracone! Jeśli mimo wszystko chcesz wyjść, kliknij jeszcze raz");
            }
            else
            {
                _navStore.CurrentViewModel = new MenuViewModel(_navStore);
            }
            
        }
    }
}
