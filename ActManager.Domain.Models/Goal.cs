using Prism.Mvvm;
using System.ComponentModel;
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
        public GoalStatus Status { get; set; }
        public List<Act>? Acts { get; set; } = new();

    }

    public enum GoalStatus : int
    {
        [Description("Создана")]
        Created = 0,
        [Description("В процессе")]
        InProgress = 1,
        [Description("Отложена")]
        Pending = 2,
        [Description("Завершена")]
        Finish = 3,
        [Description("Закрыта")]
        Closed = 10
    }
}
