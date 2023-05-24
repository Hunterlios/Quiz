using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Quiz.Model;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;

namespace Quiz.ViewModel
{
    internal class CreateViewModel: BaseViewModel
    {
        private string _selectedItem;

        public ICommand NavigateMenuCommand { get; }
        public ICommand NavigateToCreateNameCommand { get; }

        public List<string> Items { get; set; }
        
        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                showMess(_selectedItem);
            }
        }

        public CreateViewModel(NavigationStore navStore)
        {
            NavigateMenuCommand = new NavigateMenuCommand(navStore);
            NavigateToCreateNameCommand = new NavigateToCreateNameCommand(navStore, null);
            Items = new List<string>
            {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5",
            "Item 6",
            "Item 5",
            "Item 6",
            "Item 5",
            "Item 6",
            "Item 5",
            "Item 6"

            };
        }

        private void showMess(string select)
        {
            MessageBox.Show(select, "Selected Item");
        }

    }
}
