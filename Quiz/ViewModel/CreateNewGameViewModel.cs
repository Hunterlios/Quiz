﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Quiz.Model;
using Quiz.Model.Navigation;
using Quiz.ViewModel.BaseClass;

namespace Quiz.ViewModel
{
    internal class CreateNewGameViewModel : BaseViewModel
    {
        public ICommand NavigateMenuCommand { get; }

        public CreateNewGameViewModel(NavigationStore navStore)
        {
            NavigateMenuCommand = new NavigateMenuCommand(navStore);
        }
    }
}