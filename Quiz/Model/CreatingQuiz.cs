using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    public class CreatingQuiz
    {
        public string Name { get; set; }
        public List<Question> questions;
        public int iterator;

        public CreatingQuiz(string name)
        {
            iterator = 0;
            questions = new List<Question>();
            Name = name;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Quiz Name: {Name}");
            sb.AppendLine("Questions:");

            foreach (Question question in questions)
            {
                sb.AppendLine(question.ToString());
            }

            return sb.ToString();
        }

    }
}
