using Quiz.Model;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz.ViewModel
{
    internal class CreateNameViewModel : BaseViewModel
    {
        public ICommand NavigateToCreateCommand { get; }
        public ICommand NavigateToCreateQuestionCommand { get; }

        public CreateNameViewModel(NavigationStore navStore)
        {
            NavigateToCreateCommand = new NavigateToCreateCommand(navStore);
            NavigateToCreateQuestionCommand = new NavigateToCreateQuestionCommand(navStore);
        }
    }
}
