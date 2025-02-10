using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ActManager.Modules.Header.Components.ViewModels
{
    public class TodayComponentViewModel : BindableBase
    {
        private string _today;

        public string ToDay
        {
            get => _today;
            set => SetProperty(ref _today, value);
        }
        public TodayComponentViewModel()
        {
            ToDay = DateTime.Now.ToString("d MMMM yyyy г");
        }
    }
}
