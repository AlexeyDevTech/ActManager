using ActManager.Core;
using ActManager.Modules.MainMenu.Components.Views;
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
            _regionManager.RegisterViewWithRegion("MainMenuToDoListRegion", containerProvider.Resolve<ToDoListComponentView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainMenuView>("MainMenu");
        }
    }
}