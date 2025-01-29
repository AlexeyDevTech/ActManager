using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace ActManager.Modules.LeftBoard.ViewModels
{
    public class LeftBoardViewModel : BindableBase
    {
        public ObservableCollection<Building> Constructions { get; set; }

        public LeftBoardViewModel()
        {
            Constructions = new ObservableCollection<Building>();
            var rep = new BuildingsRepository();
            var list = rep.GetAll();
            foreach (var item in list)
            {
                Constructions.Add(item);
            }
        }
    }
}
