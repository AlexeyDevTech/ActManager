using ActManager.Modules.LeftBoard.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.LeftBoard
{
    public class LeftBoardModule : IModule
    {
        private IRegionManager regionManager;

        public LeftBoardModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RegisterViewWithRegion("LeftBoardRegion", containerProvider.Resolve<LeftBoardView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}