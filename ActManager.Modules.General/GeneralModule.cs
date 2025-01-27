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
            
            _regionManager.RegisterViewWithRegion("ContentRegion", containerProvider.Resolve<GeneralView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<>
        }
    }
}