using ActManager.Domain;
using ActManager.Domain.Repositories;
using ActManager.Modules.CalendarMenu.Components.ViewModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ActManager.Modules.CalendarMenu.ViewModels
{
	public class CalendarTaskViewModel : BindableBase, INavigationAware
	{
        private ObservableCollection<TaskItemViewModel> _tasks;

        public ObservableCollection<TaskItemViewModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        public CalendarTaskViewModel()
        {
            Tasks = new ObservableCollection<TaskItemViewModel>();
            //{
            //    new TaskItemViewModel{Title = "Task1", Description="description 1"},
            //    new TaskItemViewModel{Title = "Task2", Description="description 2"},
            //    new TaskItemViewModel{Title = "Task3", Description="description 3"},
            //};
            using (var db = new ApplicationDbContext())
            {
                var rep = new GoalRepository(db);
                var goals = rep.GetAll();
                foreach (var item in goals)
                {
                    var tsk = new TaskItemViewModel
                    {
                        Title = item.Title,
                        Description = item.Description,
                        GoalInstance = item
                    };
                    Tasks.Add(tsk);
                }
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }

   
}
