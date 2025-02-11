using Prism.Mvvm;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    public class Goal : BindableBase
    {
        private int _id;
        private string _title;
        private string? _description;
        private GoalStatus _status;
        private GoalPriority _priority;
        private Customer? _customer;

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
        public GoalStatus Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }
        public GoalPriority Priority
        {
            get => _priority;
            set => SetProperty(ref _priority, value);
        }
        [ForeignKey("CustomerID")]
        public Customer? Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        public List<Act>? Acts { get; set; } = new();

    }


    public enum GoalPriority : int
    {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3,
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
