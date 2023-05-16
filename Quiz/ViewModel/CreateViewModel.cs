using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quiz.Model;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;

namespace Quiz.ViewModel
{
    internal class CreateViewModel: BaseViewModel
    {
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateToCreateNameCommand { get; }

        public CreateViewModel(NavigationStore navStore)
        {
            NavigateMenuCommand = new NavigateMenuCommand(navStore);
            NavigateToCreateNameCommand = new NavigateToCreateNameCommand(navStore);
        }

    }
}
