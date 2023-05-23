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
        
        private string _questionName;
        private CreateNameViewModel _nameViewModel;
        
        public string QuestionName
        {
            get { return _questionName; }
            set
            {
                if (_questionName != value)
                {
                    _questionName = value;
                    OnPropertyChanged(nameof(QuestionName));
                }
            }
        }

        public ICommand NavigateToCreateNameCommand { get; }

        public CreateQuestionViewModel(NavigationStore navStore, CreateNameViewModel createNameViewModel)
        {   
            NavigateToCreateNameCommand = new NavigateToCreateNameCommand(navStore);
            _nameViewModel = createNameViewModel;
            _questionName = _nameViewModel.Name;
        }
    }
}
