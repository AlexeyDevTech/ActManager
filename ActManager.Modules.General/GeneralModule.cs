using ActManager.Core;
using ActManager.Modules.General.Components.Views;
using ActManager.Modules.General.ViewModels;
using ActManager.Modules.General.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.General
{
    public class GeneralModule : IModule
    {
        private IRegionManager _regionManager;

        public GeneralModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, containerProvider.Resolve<GeneralView>);
            _regionManager.RegisterViewWithRegion(RegionNames.GeneralContentRegion, containerProvider.Resolve<MainMenuView>);
            _regionManager.RegisterViewWithRegion("MainMenuItem1", containerProvider.Resolve<TodayComponentView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainMenuView>("MainMenu");
            //containerRegistry.RegisterForNavigation<>
        }
    }
}