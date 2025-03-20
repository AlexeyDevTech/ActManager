using ActManager.Modules.CalendarMenu.Components.Views;
using ActManager.Modules.CalendarMenu.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Modules.CalendarMenu
{
    public class CalendarMenuModule : IModule
    {
        private IRegionManager regionManager;

        public CalendarMenuModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            regionManager.RegisterViewWithRegion("CalendarComponentRegion", containerProvider.Resolve<CalendarComponentView>);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CalendarTaskView>("Calendar");
        }
    }
}