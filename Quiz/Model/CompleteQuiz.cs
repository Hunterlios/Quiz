using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class CompleteQuiz
    {
        string nameOfTheQuiz;
        List<Question> questionlist;

        public CompleteQuiz(string nameOfTheQuiz, List<Question> questionlist)
        {
            this.nameOfTheQuiz = nameOfTheQuiz;
            this.questionlist = questionlist;
        }
    }
}
