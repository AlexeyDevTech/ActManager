using ActManager.Domain;
using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using ActManager.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ActManager.Forms.ViewModels
{
    public class PaymentFormViewModel : BindableBase
    {

        private IEventAggregator _eventAggregator;
        private Payment _payment;
        private Contract _selectedContract;
        private ObservableCollection<Contract> _contracts;

        public PaymentFormViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Payment = new Payment();
            Payment.PaymentDate = DateTime.Now;
            Payment.DueDate = DateTime.Now;
            Contracts = new ObservableCollection<Contract>();
            StatusOptions = new ObservableCollection<string> { "Pending", "Paid", "Overdue" };
            SourceOptions = new ObservableCollection<string> { "manual", "bank", "auto" };

            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);

            GetListContracts();
        }

        private void GetListContracts()
        {
            using (var db = new ApplicationDbContext())
            {
                var rep = new ContractRepository(db);
                var l = rep.GetAll();
                foreach (var contract in l)
                {
                    _contracts.Add(contract);
                }
            }
        }


        public Payment Payment
        {
            get => _payment;
            set => SetProperty(ref _payment, value);
        }

        public Contract SelectedContract
        {
            get => _selectedContract;
            set
            {
                SetProperty(ref _selectedContract, value);
                if (value != null)
                    Payment.Contract = value;
            }
        }

        public ObservableCollection<Contract> Contracts
        {
            get => _contracts;
            set => SetProperty(ref _contracts, value);
        }

        public ObservableCollection<string> StatusOptions { get; }
        public ObservableCollection<string> SourceOptions { get; }

        public DelegateCommand SaveCommand { get; }
        public DelegateCommand CancelCommand { get; }

        private void Save()
        {
            using (var db = new ApplicationDbContext())
            {
                var rep = new PaymentRepository(db);
                rep.Add(Payment);
                _eventAggregator.GetEvent<UpdateDBEvent>().Publish(new() { TableName =  nameof(Payment), Instance = Payment });
            }
        }

        private void Cancel()
        {
            // Логика отмены
            // Например, закрытие формы
            _eventAggregator.GetEvent<PanelToggleEvent>().Publish(false);
        }

        // Метод для загрузки списка контрактов
        public void LoadContracts()
        {
            // Здесь должна быть логика загрузки контрактов из БД
            // Пример:
            // Contracts = new ObservableCollection<Contract>(contractService.GetAllContracts());
        }
    }
}
