using ActManager.Domain;
using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace ActManager.Modules.MainMenu.Components.ViewModels
{
    public class ToDoListComponentViewModel : BindableBase
    {
        private ObservableCollection<Goal> _goals;

        public ObservableCollection<Goal> Goals
        {
            get => _goals;
            set => SetProperty(ref _goals, value);
        }

        public ToDoListComponentViewModel()
        {
            Goals = new ObservableCollection<Goal>();
            using(var db = new ApplicationDbContext())
            {
                var rep = new GoalRepository(db);
                var list = rep.GetAll();
                foreach (var item in list)  
                {
                    Goals.Add(item);
                }
            }
        }
    }
}
