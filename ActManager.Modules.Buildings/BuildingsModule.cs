using ActManager.Modules.Buildings.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.Buildings
{
    public class BuildingsModule: IModule
    {
        private IRegionManager _regionManager;
        public BuildingsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //register components...
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //register navigation...
            containerRegistry.RegisterForNavigation<BuildingMenuView>("Buildings");

        }
    }
}