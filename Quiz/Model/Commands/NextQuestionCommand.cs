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
    internal class NextQuestionCommand : ICommand
    {
        QuizViewModel _quizViewModel;
        NavigationStore _navStore;

        public NextQuestionCommand(NavigationStore navigationStore,QuizViewModel QuizViewModel)
        {
            _navStore = navigationStore;
            _quizViewModel = QuizViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(!string.IsNullOrEmpty(_quizViewModel.correctAnswer))
            {
                if(_quizViewModel.correctAnswer == _quizViewModel.questions[_quizViewModel.QuestionNumber - 1].CorrectAnswer)
                {
                    _quizViewModel.CorrectAnswers++;
                }
                _quizViewModel.QuestionNumber++;
                if (_quizViewModel.QuestionNumber <= _quizViewModel.questions.Count)
                {  
                    _quizViewModel.theQuestion = _quizViewModel.questions[_quizViewModel.QuestionNumber - 1].TheQuestion;
                    _quizViewModel.answerA = _quizViewModel.questions[_quizViewModel.QuestionNumber - 1].AnswerA;
                    _quizViewModel.answerB = _quizViewModel.questions[_quizViewModel.QuestionNumber - 1].AnswerB;
                    _quizViewModel.answerC = _quizViewModel.questions[_quizViewModel.QuestionNumber - 1].AnswerC;
                    _quizViewModel.answerD = _quizViewModel.questions[_quizViewModel.QuestionNumber - 1].AnswerD;
                }
                else
                {
                    _quizViewModel.QuestionNumber--;
                    MessageBox.Show($"Koniec gry.\nIlość poprawnych odpowiedzi: {_quizViewModel.CorrectAnswers}.");
                    _quizViewModel.QuestionNumber = 1;
                    _quizViewModel.theQuestion = String.Empty;
                    _quizViewModel.answerA = String.Empty;
                    _quizViewModel.answerB = String.Empty;
                    _quizViewModel.answerC = String.Empty;
                    _quizViewModel.answerD = String.Empty;
                    _quizViewModel.correctAnswer = String.Empty;
                    _navStore.CurrentViewModel = new MenuViewModel(_navStore);
                }
                
                         
            }
            else
            {
                MessageBox.Show("Musisz wybrać odpowiedź!");
            }
        }

    }
}
