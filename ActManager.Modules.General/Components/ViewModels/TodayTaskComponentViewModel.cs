using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActManager.Modules.General.Components.ViewModels
{
    public class TodayTaskComponentViewModel : BindableBase
    {
        private int _taskLost;

        public int TaskLost
        {
            get => _taskLost;
            set => SetProperty(ref _taskLost, value);
        }

        public TodayTaskComponentViewModel()
        {

        }
    }
}
