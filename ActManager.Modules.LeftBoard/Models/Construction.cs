using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace ActManager.Modules.LeftBoard.Models
{
    public class Construction : BindableBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ObservableCollection<Contract> Contracts { get; set; }
    }
}
