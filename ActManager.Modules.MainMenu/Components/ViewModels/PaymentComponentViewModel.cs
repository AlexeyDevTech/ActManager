using ActManager.Domain.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ActManager.Modules.MainMenu.Components.ViewModels
{
    public class PaymentComponentViewModel : BindableBase
    {
        private ObservableCollection<Payment> _payments;

        public ObservableCollection<Payment> Payments
        {
            get => _payments;
            set => SetProperty(ref _payments, value);
        }


        public PaymentComponentViewModel()
        {
            Payments = new ObservableCollection<Payment>()
            {
                new Payment
                {
                    Amount = 1500.0,
                    PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
                    DueDate = DateTime.Now.AddDays(10),
                    Status = "Оплачен",
                    Contract = new()
                    {
                        Id = 4,
                        PropertyId = 1,
                        TenantName = "Ivan Petrov",
                        Room = "office 1",
                        Amount = 1900.0,
                        StartDate = new DateTime(2025, 03,01),
                        EndDate = new DateTime(2025, 06,01),
                        Status = "активен",
                        PenaltyRate = 0.1,
                        IndexationRate = 0.23
                    }
                },
                new Payment
                {
                    Amount = 1900.0,
                    PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
                    DueDate = DateTime.Now.AddDays(10),
                    Status = "Обработка",
                    Contract = new()
                    {
                        Id = 3,
                        PropertyId = 1,
                        TenantName = "Ivan Petrov",
                        Room = "office 1",
                        Amount = 1900.0,
                        StartDate = new DateTime(2025, 03,01),
                        EndDate = new DateTime(2025, 06,01),
                        Status = "активен",
                        PenaltyRate = 0.1,
                        IndexationRate = 0.23
                    }
                },
                new Payment
                {
                    Amount = 23000.0,
                    PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
                    DueDate = DateTime.Now.AddDays(10),
                    Status = "Просрочен",
                    Contract = new()
                    {
                        Id = 1,
                        PropertyId = 1,
                        TenantName = "Ivan Petrov",
                        Room = "office 1",
                        Amount = 1900.0,
                        StartDate = new DateTime(2025, 03,01),
                        EndDate = new DateTime(2025, 06,01),
                        Status = "активен",
                        PenaltyRate = 0.1,
                        IndexationRate = 0.23
                    }
                },
                new Payment
                {
                    Amount = 1000.0,
                    PaymentDate = DateTime.Now - TimeSpan.FromDays(10),
                    DueDate = DateTime.Now.AddDays(10),
                    Status = "Оплачен",
                    Contract = new()
                    {
                        Id = 2,
                        PropertyId = 1,
                        TenantName = "Ivan Petrov",
                        Room = "office 1",
                        Amount = 1900.0,
                        StartDate = new DateTime(2025, 03,01),
                        EndDate = new DateTime(2025, 06,01),
                        Status = "активен",
                        PenaltyRate = 0.1,
                        IndexationRate = 0.23
                    }
                }
            };
        }
    }
}
