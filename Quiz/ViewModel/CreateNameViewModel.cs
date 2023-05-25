using Quiz.Model;
using Quiz.Model.Data;
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
        public List<Question> questionsEdit = new List<Question>();
        public Boolean isEdit;

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
            isEdit = false;
            NavigateToCreateCommand = new NavigateToCreateCommand(navStore);
            NavigateToCreateQuestionCommand = new NavigateToCreateQuestionCommand(navStore, this);
        }

        public CreateNameViewModel(NavigationStore navStore, string quizName, int quizId)
        {
            Name = quizName;
            questionsEdit = DataContext.GetQuestions(quizId);
            isEdit = true;
            NavigateToCreateCommand = new NavigateToCreateCommand(navStore);
            NavigateToCreateQuestionCommand = new NavigateToCreateQuestionCommand(navStore, this);
        }

    }
}
