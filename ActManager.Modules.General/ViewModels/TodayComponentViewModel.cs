using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActManager.Modules.General.ViewModels
{
    public class TodayComponentViewModel : BindableBase
    {
        private int _day;
        private int _month;

        public int Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }
        public int Month
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }
        public TodayComponentViewModel()
        {
            var today = DateTime.Today;
            Day = today.Day;
            Month = today.Month;
        }
    }
}
