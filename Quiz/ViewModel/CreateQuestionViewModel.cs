﻿using Quiz.Model;
using Quiz.Model.Commands;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quiz.ViewModel
{
    internal class CreateQuestionViewModel : BaseViewModel
    {
        
        private string _quizName;
        private string _theQuestion;
        private string _answerA;
        private string _answerB;
        private string _answerC;
        private string _answerD;
        private string _correctAnswer;
        private int _questionNumber = 1;
        public bool isConfirmed;
        public bool goBack;
        private CreateNameViewModel _nameViewModel;
        public CreatingQuiz creatingQuiz;


        public ICommand NavigateToCreateNameCommand { get; }
        public ICommand CreateNextQuestionCommand { get; }
        public ICommand PreviousQuestionCommand { get; }
        public ICommand ConfirmCreatingCommand { get; }

        public CreateQuestionViewModel(NavigationStore navStore, CreateNameViewModel createNameViewModel)
        {
            isConfirmed = false;
            goBack = false;
            NavigateToCreateNameCommand = new NavigateToCreateNameCommand(navStore, this);
            CreateNextQuestionCommand = new CreateNextQuestionCommand(this);
            PreviousQuestionCommand = new PreviousQuestionCommand(this);
            ConfirmCreatingCommand = new ConfirmCreatingCommand(this);
            _nameViewModel = createNameViewModel;
            QuizName = _nameViewModel.Name;
            creatingQuiz = new CreatingQuiz(_nameViewModel.Name);
        }

        public string QuizName
        {
            get { return _quizName; }
            set
            {
                if (_quizName != value)
                {
                    _quizName = value;
                    OnPropertyChanged(nameof(QuizName));
                }
            }
        }

        public int QuestionNumber
        {
            get { return _questionNumber; }
            set { _questionNumber = value; OnPropertyChanged(nameof(QuestionNumber)); }
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
