using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Modules.Header.ViewModels
{
    public class HeaderViewModel : BindableBase
    {
        private string _message;
        private string _userName;

        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }
        public HeaderViewModel()
        {
            Message = "View A from your Prism Module";
            UserName = "Прозоров Алексей";
        }
    }
}
