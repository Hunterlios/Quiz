using System;
using System.Collections.Generic;
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
    internal class CreateViewModel: BaseViewModel
    {
        private string _selectedItem;
        private List<CompletedQuiz> quizes;
        private NavigationStore navigationStore;
        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateToCreateNameCommand { get; }

        public List<string> Items { get; set; }
        
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                showMess(_selectedItem);
            }
        }

        public CreateViewModel(NavigationStore navStore)
        {
            navigationStore = navStore;
            quizes = new List<CompletedQuiz>();

            DataContext.GetQuizzes().ForEach(x => quizes.Add(x));

            List<string> nameOfQuizes = new List<string>();
            foreach (var quiz in quizes)
            {
                nameOfQuizes.Add(quiz.NameOfTheQuiz);
            }

            //Add(DataContext.GetQuestions(currQuiz.Id));

            NavigateMenuCommand = new NavigateMenuCommand(navStore);
            NavigateToCreateNameCommand = new NavigateToCreateNameCommand(navStore, null);
            Items = nameOfQuizes;
        }

        private void showMess(string select)
        {
            foreach (var quiz in quizes)
            {
                if (quiz.NameOfTheQuiz == select)
                {
                    navigationStore.CurrentViewModel = new CreateNameViewModel(navigationStore, select, quiz.Id);
                    MessageBox.Show(select, quiz.Id.ToString());
                }
                
            }         
        }

    }
}
