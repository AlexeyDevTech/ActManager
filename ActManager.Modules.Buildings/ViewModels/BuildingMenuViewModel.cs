using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ActManager.Modules.Buildings.ViewModels
{
    public class BuildingMenuViewModel : BindableBase, INavigationAware
	  {
        private ObservableCollection<Building> _buildings;
        private Building _selBuilding;

        public Building SelBuilding
        {
            get => _selBuilding;
            set => SetProperty(ref _selBuilding, value);
        }
        public ObservableCollection<Building> Buildings
        {
            get => _buildings;
            set => SetProperty(ref _buildings, value);
        }
        public BuildingMenuViewModel()
        {
            using(var rep = new BuildingsRepository())
            {
                Buildings = new ObservableCollection<Building>();
                 var r = rep.GetAll();
                foreach(var item in r)
                    Buildings.Add(item);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
