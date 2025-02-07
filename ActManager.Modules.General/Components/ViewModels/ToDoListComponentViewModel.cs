using ActManager.Domain.Models;
using ActManager.Domain.Repositories;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ActManager.Modules.General.Components.ViewModels
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
            using(var rep = new GoalRepository())
            {
                var list = rep.GetAll();
                foreach (var item in list)
                {
                    Goals.Add(item);
                }
            }
        }
    }
}
