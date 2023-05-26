using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Quiz.Model;
using Quiz.Model.Commands;
using Quiz.Model.Data;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;

namespace Quiz.ViewModel
{
    internal class CreateViewModel: BaseViewModel
    {
        public Boolean eraseMode;
        public string removeButtonContent;
        private string _selectedItem;
        private List<CompletedQuiz> quizes;
        private NavigationStore navigationStore;

        private ObservableCollection<string> _items;

        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateToCreateNameCommand { get; }

        public ICommand EreaseTheQuestions { get; }

        public ObservableCollection<string> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public string RemoveButtonContent
        {
            get { return removeButtonContent; }
            set
            {
                if (removeButtonContent != value)
                {
                    removeButtonContent = value;
                    OnPropertyChanged(nameof(removeButtonContent));
                }
            }
        }

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
            eraseMode = false;
            removeButtonContent = "Przejdź do trybu usuwania quizów";
            navigationStore = navStore;
            quizes = new List<CompletedQuiz>();

            DataContext.GetQuizzes().ForEach(x => quizes.Add(x));

            ObservableCollection<string> nameOfQuizes = new ObservableCollection<string>();
            foreach (var quiz in quizes)
            {
                nameOfQuizes.Add(quiz.NameOfTheQuiz);
            }

            //Add(DataContext.GetQuestions(currQuiz.Id));
            EreaseTheQuestions = new EreaseTheQuestions(this);
            NavigateMenuCommand = new NavigateMenuCommand(navStore);
            NavigateToCreateNameCommand = new NavigateToCreateNameCommand(navStore, null);
            Items = nameOfQuizes;
        }

        private void showMess(string select)
        {
            if (!eraseMode)
            {
                foreach (var quiz in quizes)
                {
                    if (quiz.NameOfTheQuiz == select)
                    {
                        navigationStore.CurrentViewModel = new CreateNameViewModel(navigationStore, select, quiz.Id);
                    }
                }
            }
            else
            {
                foreach (var quiz in quizes)
                {
                    if (quiz.NameOfTheQuiz == select)
                    {
                        Items.Remove(quiz.NameOfTheQuiz);
                        DataContext.RemoveQuiz(quiz.Id);
                        break;
                    }
                }
            }
        }

    }
}
