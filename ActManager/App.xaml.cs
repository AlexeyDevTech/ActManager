using ActManager.Modules.General;
using ActManager.Modules.InfoBoard;
using ActManager.Modules.Header;
using ActManager.Modules.LeftBoard;
using ActManager.Modules.RightBoard;
using ActManager.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using Prism.Unity;

namespace ActManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<GeneralModule>();
            moduleCatalog.AddModule<InfoBoardModule>();
            moduleCatalog.AddModule<HeaderModule>();
            moduleCatalog.AddModule<LeftBoardModule>();
            moduleCatalog.AddModule<RightBoardModule>();
        }
    }
}
