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
    internal class ConfirmCreatingCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        CreateQuestionViewModel _createQuestionViewModel;

        public ConfirmCreatingCommand(CreateQuestionViewModel createQuestionViewModel)
        {
            _createQuestionViewModel = createQuestionViewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (string.IsNullOrEmpty(_createQuestionViewModel.theQuestion) ||
                    string.IsNullOrEmpty(_createQuestionViewModel.answerA) ||
                    string.IsNullOrEmpty(_createQuestionViewModel.answerB) ||
                    string.IsNullOrEmpty(_createQuestionViewModel.answerC) ||
                    string.IsNullOrEmpty(_createQuestionViewModel.answerD) ||
                    string.IsNullOrEmpty(_createQuestionViewModel.correctAnswer))
            {
                MessageBox.Show("Dokończ tworzenie bieżącego pytania zanim stowrzysz Quiz");
            }
            else
            {

                if (_createQuestionViewModel.isConfirmed)
                {

                    Question currQue = new Question(_createQuestionViewModel.creatingQuiz.iterator, _createQuestionViewModel.theQuestion,
                                              _createQuestionViewModel.answerA,
                                              _createQuestionViewModel.answerB,
                                              _createQuestionViewModel.answerC,
                                              _createQuestionViewModel.answerD,
                                              _createQuestionViewModel.correctAnswer);
                    if (_createQuestionViewModel.creatingQuiz.iterator == _createQuestionViewModel.creatingQuiz.questions.Count)
                    {
                        _createQuestionViewModel.creatingQuiz.questions.Add(currQue);
                    }
                    else
                    {
                        _createQuestionViewModel.creatingQuiz.questions[_createQuestionViewModel.creatingQuiz.iterator] = currQue;
                    }
                }
                else
                {
                    MessageBox.Show("Jeśli chcesz zakończycz tworzenie quizu kliknij ten przycisk jeszcze raz");
                    _createQuestionViewModel.isConfirmed = !_createQuestionViewModel.isConfirmed;
                }
            }
              
        }
    }
}
