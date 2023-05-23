using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class CreatingQuiz
    {
        private string Name { get; set; }
        public List<Question> questions = new List<Question>();
        public int iterator;


        public CreatingQuiz(string name)
        {
            iterator = 0;
            Name = name;
        }


    }
}
