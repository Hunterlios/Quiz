using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quiz.Model;
using Quiz.Model.Data;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;

namespace Quiz.ViewModel
{
    internal class CreateNewGameViewModel : BaseViewModel
    {
        public ICommand NavigateMenuCommand { get; }
        public static ObservableCollection<string> FoundedQuizzes { get; set; } = new ObservableCollection<string>();

        public static void SearchQuizzes()
        {
            FoundedQuizzes.Clear();
            DataContext.GetQuizzes().ForEach(x => FoundedQuizzes.Add(x.NameOfTheQuiz));
        }

        public CreateNewGameViewModel(NavigationStore navStore)
        {
            SearchQuizzes();
            NavigateMenuCommand = new NavigateMenuCommand(navStore);
        }
    }
}
