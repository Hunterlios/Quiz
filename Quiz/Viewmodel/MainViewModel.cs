using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quiz.ViewModel.BaseClass;
using Quiz.View;
namespace Quiz.ViewModel
{
    internal class MainViewModel : BaseViewModel 
    {
        public BaseViewModel CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new MenuViewModel();
        }

    }
}
