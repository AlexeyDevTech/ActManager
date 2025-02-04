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

        public ObservableCollection<Building> Constructions { get; set; }

        public ICommand SelectCommand { get; set; }
        public LeftBoardViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            //commands
            SelectCommand = new DelegateCommand<object>(SelectBuilding);
            Constructions = new ObservableCollection<Building>();
            var rep = new BuildingsRepository();
            var list = rep.GetAll();
            foreach (var item in list)
            {
                Constructions.Add(item);
            }
        }

        private void SelectBuilding(object obj)
        {
            int inst = (int)obj;
            var bld = Constructions.FirstOrDefault(x => x.ID == inst);
            Debug.WriteLine(bld.Name);

            var param = new NavigationParameters();
            param.Add("BuildingItem", bld);
            regionManager.RequestNavigate(RegionNames.GeneralContentRegion, "SelectBuilding", param);
        }
    }
}
