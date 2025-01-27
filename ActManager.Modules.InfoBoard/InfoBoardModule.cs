using ActManager.Modules.InfoBoard.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.InfoBoard
{
    public class InfoBoardModule : IModule
    {
        private IRegionManager _regionManager;

        public InfoBoardModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;

        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("InfoBoardRegion", containerProvider.Resolve<InfoBoardView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}