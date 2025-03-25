using ActManager.Domain;
using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using ActManager.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ActManager.Modules.MainMenu.Components.ViewModels
{
    public class PaymentComponentViewModel : BindableBase
    {
        private ObservableCollection<Payment> _payments;
        private int _overduePayments;
        private IEventAggregator _eventAggregator;

        public ICommand CreateActCommand { get; set; }
        public int OverduePayments 
        {
            get => _overduePayments;
            set => SetProperty(ref _overduePayments, value);
        }

        public ObservableCollection<Payment> Payments
        {
            get => _payments;
            set => SetProperty(ref _payments, value);
        }



        public void GetPaymentList()
        {
            using(var db = new ApplicationDbContext())
            {
                var rep = new PaymentRepository(db);
                var r = rep.GetAll();
                foreach(var item in r)
                {
                    Payments.Add(item);
                }
            }
        }

        public PaymentComponentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<UpdateDBEvent>().Subscribe(x => GetPaymentList());
            CreateActCommand = new DelegateCommand(CreateAct);
            Payments = new ObservableCollection<Payment>();
            Payments.CollectionChanged += Payments_CollectionChanged;
            //Payments = new ObservableCollection<Payment>()
            //{
            //    new Payment
            //    {
            //        Amount = 1500.0,
            //        PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
            //        DueDate = DateTime.Now.AddDays(10),
            //        Status = "Оплачен",
            //        Contract = new()
            //        {
            //            Id = 4,
            //            PropertyId = 1,
            //            TenantName = "Ivan Petrov",
            //            Room = "office 1",
            //            Amount = 1900.0,
            //            StartDate = new DateTime(2025, 03,01),
            //            EndDate = new DateTime(2025, 06,01),
            //            Status = "активен",
            //            PenaltyRate = 0.1,
            //            IndexationRate = 0.23
            //        }
            //    },
            //    new Payment
            //    {
            //        Amount = 1900.0,
            //        PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
            //        DueDate = DateTime.Now.AddDays(10),
            //        Status = "Обработка",
            //        Contract = new()
            //        {
            //            Id = 3,
            //            PropertyId = 1,
            //            TenantName = "Ivan Petrov",
            //            Room = "office 1",
            //            Amount = 1900.0,
            //            StartDate = new DateTime(2025, 03,01),
            //            EndDate = new DateTime(2025, 06,01),
            //            Status = "активен",
            //            PenaltyRate = 0.1,
            //            IndexationRate = 0.23
            //        }
            //    },
            //    new Payment
            //    {
            //        Amount = 23000.0,
            //        PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
            //        DueDate = DateTime.Now.AddDays(10),
            //        Status = "Просрочен",
            //        Contract = new()
            //        {
            //            Id = 1,
            //            PropertyId = 1,
            //            TenantName = "Ivan Petrov",
            //            Room = "office 1",
            //            Amount = 1900.0,
            //            StartDate = new DateTime(2025, 03,01),
            //            EndDate = new DateTime(2025, 06,01),
            //            Status = "активен",
            //            PenaltyRate = 0.1,
            //            IndexationRate = 0.23
            //        }
            //    },
            //    new Payment
            //    {
            //        Amount = 1000.0,
            //        PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
            //        DueDate = DateTime.Now.AddDays(10),
            //        Status = "Оплачен",
            //        Contract = new()
            //        {
            //            Id = 2,
            //            PropertyId = 1,
            //            TenantName = "Ivan Petrov",
            //            Room = "office 1",
            //            Amount = 1900.0,
            //            StartDate = new DateTime(2025, 03,01),
            //            EndDate = new DateTime(2025, 06,01),
            //            Status = "активен",
            //            PenaltyRate = 0.1,
            //            IndexationRate = 0.23
            //        }
            //    }
            //};
            GetPaymentList();
            
        }
        private void CreateAct()
        {
            _eventAggregator.GetEvent<PanelToggleEvent>().Publish(true);
        }

        private void Payments_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //работает исправно только если объектов меньше 1000 (придумать другое решение)
            OverduePayments = (sender as ObservableCollection<Payment>).Where(x => x.Status == "Просрочен").ToList().Count;
        }
    }
}
