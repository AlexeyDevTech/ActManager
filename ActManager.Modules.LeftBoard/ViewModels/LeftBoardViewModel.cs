using ActManager.Core;
using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace ActManager.Modules.LeftBoard.ViewModels
{
    public class LeftBoardViewModel : BindableBase
    {
        //basic
        IRegionManager regionManager;
        private LeftBoardMenuState _menuState;

        public LeftBoardMenuState MenuState
        {
            get => _menuState;
            set => SetProperty(ref _menuState, value);
        }

        public ICommand SelectMenuCommand { get; set; }

        public LeftBoardViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            //commands
            SelectMenuCommand = new DelegateCommand<object>(SelectMenu);
           
        }

        private void SelectMenu(object obj)
        {
            int param = Int32.Parse((string)obj);
            MenuState = (LeftBoardMenuState)param;
        }
    }
    public enum LeftBoardMenuState : int
    {
        None = 0,
        MainMenu = 1,
        Calendar = 2,
        Buildings = 3,
        Acts = 4,
        Documents = 5,
        Customers = 6,
        Settings = 7,
    }
}
