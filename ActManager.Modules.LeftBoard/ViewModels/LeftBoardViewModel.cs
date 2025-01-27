using ActManager.Modules.LeftBoard.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Modules.LeftBoard.ViewModels
{
    public class LeftBoardViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public ObservableCollection<Construction> Constructions { get; set; }

        public LeftBoardViewModel()
        {
            Message = "View A from your Prism Module";
            Constructions = new ObservableCollection<Construction>
        {
            new Construction
            {
                Name = "Строительство A",
                Description = "Описание строительства A",
                Contracts = new ObservableCollection<Contract>
                {
                    new Contract
                    {
                        Name = "Контракт 1",
                        Description = "Описание контракта 1",
                        Date = DateTime.Now,
                        Acts = new ObservableCollection<Act>
                        {
                            new Act { Id = 1, Name = "Акт 1", Description = "Описание акта 1", Date = DateTime.Now },
                            new Act { Id = 2, Name = "Акт 2", Description = "Описание акта 2", Date = DateTime.Now.AddDays(1) }
                        }
                    },
                    new Contract
                    {
                        Name = "Контракт 2",
                        Description = "Описание контракта 2",
                        Date = DateTime.Now.AddMonths(1),
                        Acts = new ObservableCollection<Act>
                        {
                            new Act { Id = 3, Name = "Акт 3", Description = "Описание акта 3", Date = DateTime.Now.AddMonths(1).AddDays(2) }
                        }
                    }
                }
            }
        };
        }
    }
}
