using Prism.Mvvm;
using System.ComponentModel.DataAnnotations;

namespace ActManager.Domain.Models
{
    public class Goal : BindableBase
    {
        private int _id;
        private string _title;
        private string? _description;

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
        public List<Act>? Acts { get; set; } = new();

    }
}
