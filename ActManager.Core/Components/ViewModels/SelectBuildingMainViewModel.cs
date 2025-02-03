using ActManager.Domain.Models;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.ObjectModel;

namespace ActManager.Core.Components.ViewModels
{
    public class SelectBuildingMainViewModel : BindableBase, INavigationAware
    {
        private string? _name;
        private string? _address;
        private int _officeNum;
        private ObservableCollection<Act> _currentActs;

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
            Name = navigationContext.Parameters["Name"] as string ?? "default";
            Address = navigationContext.Parameters["Address"] as string ?? "default";
            OfficeNum = (int)navigationContext.Parameters["OfficeN"] as int? ?? 0;
        }
        private IEnumerable<Act> GetListAct()
        {

        }
    }
}
