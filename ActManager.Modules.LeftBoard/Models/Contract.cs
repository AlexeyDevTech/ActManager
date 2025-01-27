using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Modules.LeftBoard.Models
{
    public class Contract : BindableBase
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public DateTime Date { get; set; }
        public ObservableCollection<Act> Acts { get; set; }
    }
}
