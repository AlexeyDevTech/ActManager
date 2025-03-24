using ActManager.Domain;
using ActManager.Domain.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ActManager.Forms.ViewModels
{
    public class PaymentFormViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        private int _id;
        private int _contractId;
        private double _amount;
        private DateTime _paymentDate = DateTime.Now;
        private DateTime _dueDate = DateTime.Now;
        private string _status = "Pending";
        private string _source = "manual";

        public PaymentFormViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            SaveCommand = new DelegateCommand(Save);
        }

        private void Save()
        {
            using(var db = new ApplicationDbContext())
            {
                var rep = new PaymentRepository(db);
                rep.Add(new Domain.Models.Payment
                {

                });
            }
        }

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public int ContractId
        {
            get => _contractId;
            set => SetProperty(ref _contractId, value);
        }

        public double Amount
        {
            get => _amount;
            set => SetProperty(ref _amount, value);
        }

        public DateTime PaymentDate
        {
            get => _paymentDate;
            set => SetProperty(ref _paymentDate, value);
        }

        public DateTime DueDate
        {
            get => _dueDate;
            set => SetProperty(ref _dueDate, value);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public string Source
        {
            get => _source;
            set => SetProperty(ref _source, value);
        }

        public ICommand SaveCommand { get; set; }
    }
}
