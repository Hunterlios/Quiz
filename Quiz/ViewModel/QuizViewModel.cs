using Quiz.Model;
using Quiz.Model.Commands;
using Quiz.Model.Data;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Quiz.ViewModel
{
    internal class QuizViewModel : BaseViewModel
    {
        public ICommand NavigateMenuCommand { get; }
        public ICommand NextQuestionCommand { get; }
        public List<Question> questions = new List<Question>();
        private string _theQuestion;
        private string _answerA;
        private string _answerB;
        private string _answerC;
        private string _answerD;
        private string _correctAnswer;
        private int _questionNumber = 1;
        private int _correctAnswers = 0;
        

        public QuizViewModel(NavigationStore navStore, int quizId)
        {
            questions = DataContext.GetQuestions(quizId);
            if(_questionNumber <= questions.Count)
            {
                theQuestion = questions[_questionNumber - 1].TheQuestion;
                answerA = questions[_questionNumber - 1].AnswerA;
                answerB = questions[_questionNumber - 1].AnswerB;
                answerC = questions[_questionNumber - 1].AnswerC;
                answerD = questions[_questionNumber - 1].AnswerD;
            }
            else
            {
                MessageBox.Show($"Koniec gry.\nIlość poprawnych odpowiedzi: {_correctAnswers}.");
            }
            
            NavigateMenuCommand = new NavigateMenuCommand(navStore);
            NextQuestionCommand = new NextQuestionCommand(navStore, this);
        }

        public int QuestionNumber
        {
            get { return _questionNumber; }
            set { _questionNumber = value; OnPropertyChanged(nameof(QuestionNumber)); }
        }
        public int CorrectAnswers
        {
            get { return _correctAnswers; }
            set { _correctAnswers = value; OnPropertyChanged(nameof(CorrectAnswers)); }
        }

        public string theQuestion
        {
            get { return _theQuestion; }
            set { _theQuestion = value; OnPropertyChanged(nameof(theQuestion)); }
        }

        public string answerA
        {
            get { return _answerA; }
            set { _answerA = value; OnPropertyChanged(nameof(answerA)); }
        }

        public string answerB
        {
            get { return _answerB; }
            set { _answerB = value; OnPropertyChanged(nameof(answerB)); }
        }

        public string answerC
        {
            get { return _answerC; }
            set { _answerC = value; OnPropertyChanged(nameof(answerC)); }
        }

        public string answerD
        {
            get { return _answerD; }
            set { _answerD = value; OnPropertyChanged(nameof(answerD)); }
        }

        public string correctAnswer
        {
            get { return _correctAnswer; }
            set { _correctAnswer = value; OnPropertyChanged(nameof(correctAnswer)); }
        }
    }
}