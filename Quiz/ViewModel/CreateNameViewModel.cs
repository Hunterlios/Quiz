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
    public class CreateNameViewModel : BaseViewModel
    {
        private string _name;
        public event Action<string> NameUpdated;

        public string Name
        {
            get { return _name; }
            set { _name = value; 
            OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand NavigateToCreateCommand { get; }
        public ICommand NavigateToCreateQuestionCommand { get; set; }


        public CreateNameViewModel(NavigationStore navStore)
        {
            NavigateToCreateCommand = new NavigateToCreateCommand(navStore);
            NavigateToCreateQuestionCommand = new NavigateToCreateQuestionCommand(navStore, this);
        }

    }
}
