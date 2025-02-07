using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ActManager.Modules.General.Components.ViewModels
{
    public class NearestTaskComponentViewModel : BindableBase
    {
        private string _nearestTime;
        private DateTime _nearestDateTime;
        private string _nearestDate;

        public string NearestTime
        {
            get => _nearestTime;
            set
            {
                SetProperty(ref _nearestTime, value);
            }
        }
        public string NearestDate
        {
            get => _nearestDate;
            set => SetProperty(ref _nearestDate, value);
        }

        public DateTime NearestDateTime
        {
            get => _nearestDateTime;
            set
            {
                _nearestDateTime = value;
                NearestTime = ConvertTimeToString(value);
                NearestDate = ConvertDateToString(value);
            }
        }

        public NearestTaskComponentViewModel()
        {
            NearestDateTime = DateTime.Now;
            Task.Factory.StartNew(async () => await UpdateTime());
        }

        private async Task UpdateTime()
        {
            while (true)
            {
                if (NearestDateTime != DateTime.Now)
                {
                    NearestDateTime = DateTime.Now;
                }
                await Task.Delay(10000);
            }
        }

        private string ConvertTimeToString(DateTime time)
        {
            return time.ToString("H:mm");
        }
        private string ConvertDateToString(DateTime date)
        {

            return $"{date.ToString("dd MMMM yyyy")}г" ;
        }
    }
}
