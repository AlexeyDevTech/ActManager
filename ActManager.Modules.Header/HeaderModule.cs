using ActManager.Modules.Header.Components.Views;
using ActManager.Modules.Header.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.Header
{
    public class HeaderModule : IModule
    {
        private IRegionManager _regionManager;

        public HeaderModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;   
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("HeaderRegion", containerProvider.Resolve<HeaderView>);
            _regionManager.RegisterViewWithRegion("HeaderTodayRegion", containerProvider.Resolve<TodayComponentView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}