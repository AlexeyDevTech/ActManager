using ActManager.Domain;
using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;
using System.Windows.Markup.Localizer;

namespace ActManager.Core.Components.ViewModels
{
    public class SelectBuildingMainViewModel : BindableBase, INavigationAware
    {
        private string? _name;
        private string? _address;
        private int _officeNum;
        private ObservableCollection<Act> _currentActs;
        private int? BuildID;

        public string? Name
        {
            
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string? Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }
        public int OfficeNum
        {
            get => _officeNum;
            set => SetProperty(ref _officeNum, value);
        }


        public ObservableCollection<Act> CurrentActs
        {
            get => _currentActs;
            set => SetProperty(ref _currentActs, value);
        }
        public SelectBuildingMainViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            CurrentActs = new ObservableCollection<Act>();
            Name = "default";
            Address = "default";
           
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext) { }

        public void OnNavigatedTo(NavigationContext navigationContext) 
        {
            //Name = navigationContext.Parameters["Name"] as string ?? "default";
            //Address = navigationContext.Parameters["Address"] as string ?? "default";
            //OfficeNum = (int)navigationContext.Parameters["OfficeN"] as int? ?? 0;
            var bld = navigationContext.Parameters["BuildingItem"] as Building;
            BuildID = bld?.ID;
            Name = bld?.Name;
            Address = $"{bld?.AddressInst.Street}, {bld?.AddressInst.StreetNumber}";
            OfficeNum = bld?.AddressInst.OfficeNumber ?? 0;
            CurrentActs.Clear();
            foreach (var item in GetListAct())
            {
                CurrentActs.Add(item);
            }
        }
        private IEnumerable<Act> GetListAct()
        {
            var res = new List<Act>();
            using (var db = new ApplicationDbContext())
            {
                var rep = new ActRepository(db);
                if (BuildID != null)
                {
                    res = rep.GetByBuildingId(BuildID ?? 0).ToList();
                }
            }
            //using (var rep = new ActRepository())
            //{
            //    if(BuildID != null) 
            //        res = rep.GetAllFromBuiling((int)BuildID).ToList();
            //}
            return res;
        }
    }
}
