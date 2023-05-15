using Quiz.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.ViewModel.BaseClass
{
    internal class BaseViewModel
    {
        public static implicit operator BaseViewModel(MainWindowView v)
        {
            throw new NotImplementedException();
        }
    }
}
