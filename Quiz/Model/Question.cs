using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class Question
    {
        private int _id;
        private string theQuestion;
        private string answerA;
        private string answerB;
        private string answerC;
        private string answerD;
        private string correctAnswer;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        public string CorrectAnswer
        {
            get { return correctAnswer; }
            set { correctAnswer = value; }
        }

        public Question(int id, string theQuestion, string answerA, string answerB, string answerC, string answerD, string correctAnswer)
        {
            this._id = id;
            this.theQuestion = theQuestion;
            this.answerA = answerA;
            this.answerB = answerB;
            this.answerC = answerC;
            this.answerD = answerD;
            this.correctAnswer = correctAnswer;
        }

        public override string ToString()
        {
            return $"Question: {theQuestion}\n" +
                   $"A. {answerA}\n" +
                   $"B. {answerB}\n" +
                   $"C. {answerC}\n" +
                   $"D. {answerD}\n" +
                   $"Correct Answer: {correctAnswer}";
        }
    }
}
