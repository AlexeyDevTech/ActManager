using ActManager.Modules.RightBoard.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.RightBoard
{
    public class RightBoardModule : IModule
    {   
        private IRegionManager _regionManager;

        public RightBoardModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("RightBoardRegion", containerProvider.Resolve<RightBoardView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}