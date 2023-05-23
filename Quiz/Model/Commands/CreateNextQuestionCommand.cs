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
    internal class CreateNextQuestionCommand : ICommand
    {

        CreateQuestionViewModel _createQuestionViewModel;

        public CreateNextQuestionCommand(CreateQuestionViewModel createQuestionViewModel)
        {
           _createQuestionViewModel = createQuestionViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (!string.IsNullOrEmpty(_createQuestionViewModel.theQuestion) &&
             !string.IsNullOrEmpty(_createQuestionViewModel.answerA) &&
            !string.IsNullOrEmpty(_createQuestionViewModel.answerB) &&
            !string.IsNullOrEmpty(_createQuestionViewModel.answerC) &&
            !string.IsNullOrEmpty(_createQuestionViewModel.answerD) &&
            !string.IsNullOrEmpty(_createQuestionViewModel.correctAnswer))
            {
                Question currQue = new Question(_createQuestionViewModel.theQuestion,
                                                _createQuestionViewModel.answerA,
                                                _createQuestionViewModel.answerB,
                                                _createQuestionViewModel.answerC,
                                                _createQuestionViewModel.answerD,
                                                _createQuestionViewModel.correctAnswer);
                _createQuestionViewModel.creatingQuiz.questions.Add(currQue);
                _createQuestionViewModel.creatingQuiz.iterator += 1;
            }
            else
            {
                // Show warning window
                MessageBox.Show("Nie smaż lola, uzpełnij wszystkie pola");
            }

        }

       
    }
}
