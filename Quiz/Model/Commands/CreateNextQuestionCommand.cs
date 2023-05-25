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

                if (_createQuestionViewModel.creatingQuiz.iterator == _createQuestionViewModel.creatingQuiz.questions.Count)
                {
                    
                    Question currQue = new Question(_createQuestionViewModel.QuestionNumber, _createQuestionViewModel.theQuestion,
                                                _createQuestionViewModel.answerA,
                                                _createQuestionViewModel.answerB,
                                                _createQuestionViewModel.answerC,
                                                _createQuestionViewModel.answerD,
                                                _createQuestionViewModel.correctAnswer);
                    _createQuestionViewModel.creatingQuiz.questions.Add(currQue);
                    _createQuestionViewModel.theQuestion = String.Empty;
                    _createQuestionViewModel.answerA = String.Empty;
                    _createQuestionViewModel.answerB = String.Empty;
                    _createQuestionViewModel.answerC = String.Empty;
                    _createQuestionViewModel.answerD = String.Empty;
                    _createQuestionViewModel.correctAnswer = String.Empty;

                    _createQuestionViewModel.creatingQuiz.iterator += 1;
                    _createQuestionViewModel.QuestionNumber += 1;
                }
                else if (_createQuestionViewModel.creatingQuiz.iterator == _createQuestionViewModel.creatingQuiz.questions.Count - 1)
                {
                    Question prevQue = new Question(_createQuestionViewModel.QuestionNumber, _createQuestionViewModel.theQuestion,
                                               _createQuestionViewModel.answerA,
                                               _createQuestionViewModel.answerB,
                                               _createQuestionViewModel.answerC,
                                               _createQuestionViewModel.answerD,
                                               _createQuestionViewModel.correctAnswer);
                    _createQuestionViewModel.creatingQuiz.questions[_createQuestionViewModel.creatingQuiz.iterator] = prevQue;
                    _createQuestionViewModel.creatingQuiz.iterator += 1;
                    _createQuestionViewModel.QuestionNumber += 1;
                    _createQuestionViewModel.theQuestion = String.Empty;
                    _createQuestionViewModel.answerA = String.Empty;
                    _createQuestionViewModel.answerB = String.Empty;
                    _createQuestionViewModel.answerC = String.Empty;
                    _createQuestionViewModel.answerD = String.Empty;
                    _createQuestionViewModel.correctAnswer = String.Empty;
                }
                else 
                {
                    //update currQue
                    Question prevQue = new Question(_createQuestionViewModel.QuestionNumber, _createQuestionViewModel.theQuestion,
                                                _createQuestionViewModel.answerA,
                                                _createQuestionViewModel.answerB,
                                                _createQuestionViewModel.answerC,
                                                _createQuestionViewModel.answerD,
                                                _createQuestionViewModel.correctAnswer);
                    _createQuestionViewModel.creatingQuiz.questions[_createQuestionViewModel.creatingQuiz.iterator] = prevQue;
                    //move to the next Que
                    _createQuestionViewModel.creatingQuiz.iterator += 1;
                    _createQuestionViewModel.QuestionNumber += 1;
                    Question currQue = _createQuestionViewModel.creatingQuiz.questions[_createQuestionViewModel.creatingQuiz.iterator];
                    _createQuestionViewModel.theQuestion = currQue.TheQuestion;
                    _createQuestionViewModel.answerA = currQue.AnswerA;
                    _createQuestionViewModel.answerB = currQue.AnswerB;
                    _createQuestionViewModel.answerC = currQue.AnswerC;
                    _createQuestionViewModel.answerD = currQue.AnswerD;
                    _createQuestionViewModel.correctAnswer = currQue.CorrectAnswer;
                }
                
            }
            else
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola przed przejściem do następnego pytania");
            }

        }

       
    }
}
