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
    internal class CreateQuestionViewModel : BaseViewModel
    {
        public ICommand NavigateToCreateNameCommand { get; }

        public CreateQuestionViewModel(NavigationStore navStore)
        {
            NavigateToCreateNameCommand = new NavigateToCreateNameCommand(navStore);
        }
    }
}
