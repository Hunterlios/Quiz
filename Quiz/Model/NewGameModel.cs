using Quiz.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Model
{
    internal class NewGameModel
    {
        private DataContext db;

        public DataContext Db
        {
            get { return db; }
        }

        public NewGameModel()
        {
            db = new DataContext();
        }

    }
}
