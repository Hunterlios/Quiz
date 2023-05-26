using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Quiz.Model;
using Quiz.Model.Data;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;

namespace Quiz.ViewModel
{
    internal class CreateNewGameViewModel : BaseViewModel
    {
        private string _selectedItem;
        private List<CompletedQuiz> quizes;
        private NavigationStore navigationStore;
        public List<string> Items { get; set; }
        public ICommand NavigateMenuCommand { get; }

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                LoadQuiz(_selectedItem);
            }
        }

        public CreateNewGameViewModel(NavigationStore navStore)
        {
            navigationStore = navStore;
            quizes = new List<CompletedQuiz>();
            DataContext.GetQuizzes().ForEach(x => quizes.Add(x));
            List<string> nameOfQuizes = new List<string>();
            foreach (var quiz in quizes)
            {
                nameOfQuizes.Add(quiz.NameOfTheQuiz);
            }


            NavigateMenuCommand = new NavigateMenuCommand(navStore);
            Items = nameOfQuizes;
        }


        private void LoadQuiz(string select)
        {
            foreach (var quiz in quizes)
            {
                if (quiz.NameOfTheQuiz == select)
                {
                    navigationStore.CurrentViewModel = new QuizViewModel(navigationStore, quiz.Id);
                }

            }
        }
    }
}
