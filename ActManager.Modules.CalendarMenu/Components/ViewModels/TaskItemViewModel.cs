using ActManager.Domain.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ActManager.Modules.CalendarMenu.Components.ViewModels
{
	public class TaskItemViewModel : BindableBase
	{
        private string _title;
        private string _description;
        private Goal _goalInstance;

        public Goal GoalInstance
        {
            get => _goalInstance;
            set => SetProperty(ref _goalInstance, value);
        }
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                Debug.WriteLine("Title task");
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                SetProperty(ref _description, value);
                Debug.WriteLine("Description task");
            }
        }
        public TaskItemViewModel()
        {
            Debug.WriteLine("ctor task called from: " + new StackTrace().ToString());
        }
	}
}
