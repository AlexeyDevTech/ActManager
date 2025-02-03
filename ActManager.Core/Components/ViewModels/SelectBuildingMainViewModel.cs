using Prism.Mvvm;
using Prism.Regions;

namespace ActManager.Core.Components.ViewModels
{
    public class SelectBuildingMainViewModel : BindableBase, INavigationAware
    {
        private string _name;
        private string _address;

        public string Name
        {
            
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Address
        {
            get => _address;
            set => SetProperty(ref _address, value);
        }


        public SelectBuildingMainViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            Name = "default";
            Address = "default";
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext) { }

        public void OnNavigatedTo(NavigationContext navigationContext) 
        {
            Name = navigationContext.Parameters["Name"] as string ?? "default";
            Address = navigationContext.Parameters["Address"] as string ?? "default";
        }
    }
}
