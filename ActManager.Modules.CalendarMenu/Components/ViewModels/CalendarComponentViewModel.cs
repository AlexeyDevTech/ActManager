using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace ActManager.Modules.CalendarMenu.Components.ViewModels
{
	public class CalendarComponentViewModel : BindableBase
	{
        public ObservableCollection<CalendarDay> Days { get; set; }
        public string CurrentMonth => SelectedDate.ToString("MMMM yyyy");

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                SetProperty(ref _selectedDate, value);
                RaisePropertyChanged(nameof(CurrentMonth));
                GenerateCalendar();
            }
        }



        public ICommand PreviousMonthCommand { get; }
        public ICommand NextMonthCommand { get; }
        public CalendarComponentViewModel()
        {
            Days = new ObservableCollection<CalendarDay>();
            SelectedDate = DateTime.Today;

            PreviousMonthCommand = new DelegateCommand(DecrementMonth);
            NextMonthCommand = new DelegateCommand(IncrementMonth);

            GenerateCalendar();
        }
        public void DecrementMonth() => ChangeMonth(-1);
        public void IncrementMonth() => ChangeMonth(1);


        private void ChangeMonth(int offset)
        {
            SelectedDate = SelectedDate.AddMonths(offset);
        }

        private void GenerateCalendar()
        {
            Days.Clear();
            DateTime firstDay = new DateTime(SelectedDate.Year, SelectedDate.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(SelectedDate.Year, SelectedDate.Month);
            int startOffset = ((int)firstDay.DayOfWeek + 6) % 7; // Делаем так, чтобы Пн был первым днём

            // Заполняем пустые ячейки перед началом месяца
            for (int i = 0; i < startOffset; i++)
            {
                Days.Add(new CalendarDay { Day = "", Events = new ObservableCollection<CalendarEvent>() });
            }

            // Заполняем дни месяца
            for (int i = 1; i <= daysInMonth; i++)
            {
                Days.Add(new CalendarDay { Day = i.ToString(), Events = new ObservableCollection<CalendarEvent>() });
            }
            int totalDays = startOffset + daysInMonth; // Всего занятых ячеек
            int remainingCells = (7 - (totalDays % 7)) % 7; // Сколько ещё нужно добавить

            // Заполняем пустые ячейки после конца месяца
            for (int i = 0; i < remainingCells; i++)
            {
                Days.Add(new CalendarDay { Day = "", Events = new ObservableCollection<CalendarEvent>() });
            }
        }

        //private void GenCalendar()
        //{
        //    Days.Clear();

        //    DateTime firstDay = new DateTime(CurrentYear, CurrentMonth, 1);
        //    int daysInMonth = DateTime.DaysInMonth(CurrentYear, CurrentMonth);
        //    int startOffset = ((int)firstDay.DayOfWeek + 6) % 7; // Сдвиг, чтобы Пн был первым днём

        //    // Дни предыдущего месяца
        //    DateTime prevMonth = firstDay.AddMonths(-1);
        //    int prevMonthDays = DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);

        //    for (int i = startOffset - 1; i >= 0; i--)
        //    {
        //        int day = prevMonthDays - i;
        //        Days.Add(new CalendarDay
        //        {
        //            Day = day.ToString(),
        //            IsOtherMonth = true,
        //            Events = new ObservableCollection<CalendarEvent>()
        //        });
        //    }

        //    // Дни текущего месяца
        //    for (int day = 1; day <= daysInMonth; day++)
        //    {
        //        Days.Add(new CalendarDay
        //        {
        //            Day = day.ToString(),
        //            IsOtherMonth = false,
        //            Events = new ObservableCollection<CalendarEvent>()
        //        });
        //    }

        //    // Дни следующего месяца
        //    int totalDays = Days.Count;
        //    int remainingCells = (7 - (totalDays % 7)) % 7; // Сколько ячеек нужно добавить

        //    for (int i = 1; i <= remainingCells; i++)
        //    {
        //        Days.Add(new CalendarDay
        //        {
        //            Day = i.ToString(),
        //            IsOtherMonth = true,
        //            Events = new ObservableCollection<CalendarEvent>()
        //        });
        //    }
        //}
    }
    public class CalendarDay
    {
        public string Day { get; set; }
        public ObservableCollection<CalendarEvent> Events { get; set; }
    }

    public class CalendarEvent
    {
        public string Title { get; set; }
    }
}
