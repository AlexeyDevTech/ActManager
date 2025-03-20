using ActManager.Modules.General;
using ActManager.Modules.InfoBoard;
using ActManager.Modules.Header;
using ActManager.Modules.LeftBoard;
using ActManager.Modules.RightBoard;
using ActManager.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using ActManager.Core.Components.Views;
using ActManager.Core.Components.ViewModels;
using ActManager.Domain;
using ActManager.Modules.MainMenu;
using System.Globalization;
using ActManager.Modules.CalendarMenu;
using ActManager.Modules.Buildings;
using ActManager.Domain.Repositories;

namespace ActManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            var db_online = new ApplicationDbContext().DatabaseOnline();
            if (!db_online)
            {
                MessageBox.Show(messageBoxText: "подключение к базе данных прошло неудачно", "Ошибка подключения к БД", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return Container.Resolve<MainWindow>();
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SelectBuildingMainView, SelectBuildingMainViewModel>("SelectBuilding");

            //Repositories...
            containerRegistry.Register<IActRepository, ActRepository>();
            containerRegistry.Register<IAddressRepository, AddressRepository>();
            containerRegistry.Register<IAnalyticRepository, AnalyticRepository>();
            containerRegistry.Register<IBankTransactionRepository, BankTransactionRepository>();
            containerRegistry.Register<IBuildingRepository, BuildingRepository>();
            containerRegistry.Register<IContractRepository, ContractRepository>();
            containerRegistry.Register<IContractTemplateRepository, ContractTemplateRepository>();
            containerRegistry.Register<ICustomerRepository, CustomerRepository>();
            containerRegistry.Register<ICustomerAttributeRepository, CustomerAttributeRepository>();
            containerRegistry.Register<IExpenseRepository, ExpenseRepository>();
            containerRegistry.Register<IFileNameRepository, FileNameRepository>();
            containerRegistry.Register<IGoalRepository, GoalRepository>();
            containerRegistry.Register<INotificationRepository, NotificationRepository>();
            containerRegistry.Register<IPaymentRepository, PaymentRepository>();
            containerRegistry.Register<IPropertyRepository, PropertyRepository>();
            containerRegistry.Register<ITaxRepository, TaxRepository>();
            containerRegistry.Register<IUserRepository, UserRepository>();
        }
        
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            moduleCatalog.AddModule<GeneralModule>();
            moduleCatalog.AddModule<MainMenuModule>();
            moduleCatalog.AddModule<CalendarMenuModule>();
            moduleCatalog.AddModule<BuildingsModule>();
            moduleCatalog.AddModule<InfoBoardModule>();
            moduleCatalog.AddModule<HeaderModule>();
            moduleCatalog.AddModule<LeftBoardModule>();
            moduleCatalog.AddModule<RightBoardModule>();
        }
    }
}
