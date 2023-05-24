using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class CompleteQuiz
    {
        private string nameOfTheQuiz;
        List<Question> questionlist;

        public string NameOfTheQuiz { get; set; }

        public List<Question> Questions { get => questionlist; }

        public CompleteQuiz(string nameOfTheQuiz, List<Question> questionlist)
        {
            this.nameOfTheQuiz = nameOfTheQuiz;
            this.questionlist = questionlist;
        }
    }
}
