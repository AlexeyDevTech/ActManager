using ActManager.Core;
using ActManager.Modules.MainMenu.Components.Views;
using ActManager.Modules.MainMenu.Components.Views.HeadCard;
using ActManager.Modules.MainMenu.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.MainMenu
{
    public class MainMenuModule : IModule
    {
        private IRegionManager _regionManager;
        public MainMenuModule(IRegionManager regionManager)
        {
          _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.GeneralContentRegion, containerProvider.Resolve<MainMenuView>);
            //components
            _regionManager.RegisterViewWithRegion("MainMenuToDoListRegion", containerProvider.Resolve<ToDoListComponentView>);
            //head items
            _regionManager.RegisterViewWithRegion("MainMenuHeadItem1", containerProvider.Resolve<TotalCashHeadItemView>);
            _regionManager.RegisterViewWithRegion("MainMenuHeadItem2", containerProvider.Resolve<TaxCashHeadItemView>);
            _regionManager.RegisterViewWithRegion("MainMenuHeadItem3", containerProvider.Resolve<TotalCostHeadItemView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainMenuView>("MainMenu");
        }
    }
}