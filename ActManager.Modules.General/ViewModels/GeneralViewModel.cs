using Prism.Mvvm;

namespace ActManager.Modules.General.ViewModels
{
    public class GeneralViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public GeneralViewModel()
        {
            Message = "General view";
        }
    }
}
