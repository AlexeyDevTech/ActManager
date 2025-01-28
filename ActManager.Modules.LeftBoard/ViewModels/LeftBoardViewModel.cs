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
                Address = "ул. Блюхера, 36, офис 100",
            },
            new Construction
            {
                Name = "Строительство 2",
                Description = "Описание строительства A",
                Address = "ул. Блюхера, 36, офис 100",
            },
            new Construction
            {
                Name = "Строительство 3",
                Description = "Описание строительства A",
                Address = "ул. Блюхера, 36, офис 100",
            },
            new Construction
            {
                Name = "Строительство 4",
                Description = "Описание строительства A",
                Address = "ул. Блюхера, 36, офис 100",
            },
            new Construction
            {
                Name = "Строительство 5",
                Description = "Описание строительства A",
                Address = "ул. Блюхера, 36, офис 100",
            },
            new Construction
            {
                Name = "Строительство 6",
                Description = "Описание строительства A",
                Address = "ул. Блюхера, 36, офис 100",
            }

        };
        }
    }
}
