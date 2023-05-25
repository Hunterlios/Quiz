using Quiz.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Quiz.Model.Commands
{
    internal class EreaseTheQuestions : ICommand
    {
        CreateViewModel createViewModel;

        public event EventHandler? CanExecuteChanged;

        public EreaseTheQuestions(CreateViewModel createViewModel)
        {
            this.createViewModel = createViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (createViewModel.eraseMode)
            {
                createViewModel.eraseMode = !createViewModel.eraseMode;
                createViewModel.RemoveButtonContent = "Przejdź do trybu usuwania quizów";
            }
            else
            {
                createViewModel.eraseMode = !createViewModel.eraseMode;
                createViewModel.RemoveButtonContent = "Tryb usuwania, kliknij, aby przerwać";

                //mechanism of deleting


            }
        }
    }
}
