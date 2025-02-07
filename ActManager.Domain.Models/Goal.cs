using Prism.Mvvm;
using System.ComponentModel.DataAnnotations;

namespace ActManager.Domain.Models
{
    public class Goal : BindableBase
    {
        private int _id;
        private string _title;
        private string? _description;
        private IEnumerable<Act> _acts;

        public Goal()
        {
          
        }
        [Key]
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }
        IEnumerable<Act>? Acts { get; set; }

    }
}
