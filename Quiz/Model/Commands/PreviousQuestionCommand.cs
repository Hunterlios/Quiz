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
    internal class PreviousQuestionCommand : ICommand
    {

        CreateQuestionViewModel _createQuestionViewModel;

        public PreviousQuestionCommand(CreateQuestionViewModel createQuestionViewModel)
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
            if (_createQuestionViewModel.creatingQuiz.iterator > 0)
            {

                if (!string.IsNullOrEmpty(_createQuestionViewModel.theQuestion) &&
                    !string.IsNullOrEmpty(_createQuestionViewModel.answerA) &&
                    !string.IsNullOrEmpty(_createQuestionViewModel.answerB) &&
                    !string.IsNullOrEmpty(_createQuestionViewModel.answerC) &&
                    !string.IsNullOrEmpty(_createQuestionViewModel.answerD) &&
                    !string.IsNullOrEmpty(_createQuestionViewModel.correctAnswer))
                {
                    Question prevQue = new Question(_createQuestionViewModel.creatingQuiz.iterator, _createQuestionViewModel.theQuestion,
                                              _createQuestionViewModel.answerA,
                                              _createQuestionViewModel.answerB,
                                              _createQuestionViewModel.answerC,
                                              _createQuestionViewModel.answerD,
                                              _createQuestionViewModel.correctAnswer);
                    if (_createQuestionViewModel.creatingQuiz.iterator == _createQuestionViewModel.creatingQuiz.questions.Count)
                    {
                        _createQuestionViewModel.creatingQuiz.questions.Add(prevQue);
                    }
                    else
                    {
                        _createQuestionViewModel.creatingQuiz.questions[_createQuestionViewModel.creatingQuiz.iterator] = prevQue;
                    }
                    


                    _createQuestionViewModel.creatingQuiz.iterator -= 1;
                    _createQuestionViewModel.QuestionNumber -= 1;
                    Question currQue = _createQuestionViewModel.creatingQuiz.questions[_createQuestionViewModel.creatingQuiz.iterator];
                    _createQuestionViewModel.theQuestion = currQue.TheQuestion;
                    _createQuestionViewModel.answerA = currQue.AnswerA;
                    _createQuestionViewModel.answerB = currQue.AnswerB;
                    _createQuestionViewModel.answerC = currQue.AnswerC;
                    _createQuestionViewModel.answerD = currQue.AnswerD;
                    _createQuestionViewModel.correctAnswer = currQue.CorrectAnswer;
                }
                else
                {
                    MessageBox.Show("Uzupełnij bieżące pytanie, znim wrócisz do poprzedniego");
                }
                    
                
            }
            else
            {
                MessageBox.Show("Jesteś na pierwszym pytaniu, niżej już nic nie ma");
            }
            

        }

       
    }
}
