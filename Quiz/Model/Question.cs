using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class Question
    {
        private string theQuestion;
        private string answerA;
        private string answerB;
        private string answerC;
        private string answerD;
        private char correctAnswer;

        public string TheQuestion
        {
            get { return theQuestion; }
            set { theQuestion = value; }
        }

        public string AnswerA
        {
            get { return answerA; }
            set { answerA = value; }
        }

        public string AnswerB
        {
            get { return answerB; }
            set { answerB = value; }
        }

        public string AnswerC
        {
            get { return answerC; }
            set { answerC = value; }
        }

        public string AnswerD
        {
            get { return answerD; }
            set { answerD = value; }
        }

        public char CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        public Question(string theQuestion, string answerA, string answerB, string answerC, string answerD, char correctAnswer)
        {
            this.theQuestion = theQuestion;
            this.answerA = answerA;
            this.answerB = answerB;
            this.answerC = answerC;
            this.answerD = answerD;
            this.correctAnswer = correctAnswer;
        }
    }
}
