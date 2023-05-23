using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class CreatingQuiz
    {
        public string Name { get; set; }
        List<Question> questions = new List<Question>();

        public CreatingQuiz(string name)
        {
            Name = name;
            this.questions = questions;
        }


    }
}
