using Prism.Mvvm;
using System;

namespace ActManager.Modules.General.Components.ViewModels
{
    public class TodayComponentViewModel : BindableBase
    {
        private int _day;
        private string _month;
        private int _monthNumber;
        private string[] _monthNames =
        {
            "Января",
            "Февраля",
            "Марта",
            "Апреля",
            "Мая",
            "Июня",
            "Июля",
            "Августа",
            "Сентрября",
            "Октября",
            "Ноября",
            "Декабря",
        };


        public int Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }
        public string Month
        {
            get => _month;
            set => SetProperty(ref _month, value);
        }
        public int MonthNumber
        {
            get => _monthNumber;
            set
            {
                SetProperty(ref _monthNumber, value);
                var monthIndex = value - 1;
                if(monthIndex <= 0)
                    monthIndex = 0;
                if(monthIndex >= _monthNames.Length)
                    monthIndex = _monthNames.Length;
                Month = _monthNames[monthIndex];
            }
        }
        public TodayComponentViewModel()
        {
            var today = DateTime.Today;
            Day = today.Day;
            MonthNumber = today.Month;
        }
    }
    
}
