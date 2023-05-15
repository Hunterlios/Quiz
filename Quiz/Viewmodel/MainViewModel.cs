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
        private BaseViewModel _selectedViewModel = new MainWindowView();

        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set { _selectedViewModel = value; }
        }


    }
}
