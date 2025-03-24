using ActManager.Forms.ViewModels;
using ActManager.Forms.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ActManager.Forms
{
    public class FormsModule : IModule
    {
        private IRegionManager _regionManager;

        public FormsModule(IRegionManager regionManager)
        {
          _regionManager = regionManager;
        }
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion("RightPanelRegion", typeof(PaymentFormView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PaymentFormView, PaymentFormViewModel>();
        }
    }
}