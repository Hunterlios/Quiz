using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class Question
    {
        string theQuestion;
        string answerA;
        string answerB;
        string answerC;
        string answerD;
        char correctAnswer;

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
