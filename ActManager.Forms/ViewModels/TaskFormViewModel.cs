using ActManager.Domain.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActManager.Forms.ViewModels
{
    public class TaskFormViewModel : BindableBase
    {
        private Goal _goal;

        public Goal Goal
        {
            get => _goal;
            set => SetProperty(ref _goal, value);
        }

        public TaskFormViewModel()
        {

        }
    }
}
