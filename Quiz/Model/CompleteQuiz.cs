using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class CompleteQuiz
    {
        private string nameOfTheQuiz;
        private int _id;

        public string NameOfTheQuiz
        {
            get { return nameOfTheQuiz; }
            set { nameOfTheQuiz = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public CompleteQuiz(int id, string nameOfTheQuiz)
        {
            Id = id;
            NameOfTheQuiz = nameOfTheQuiz;
        }
    }
}