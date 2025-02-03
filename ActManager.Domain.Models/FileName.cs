using Prism.Mvvm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActManager.Domain.Models
{
    [Table("FileNames")]
    public class FileName : BindableBase
    {
        private int _id;
        private string _path;
        private Act? _act;

        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        [Required]
        public string Path
        {
            get => _path;
            set => SetProperty(ref _path, value);
        }

        [ForeignKey("ActID")]
        public Act? Act
        {
            get => _act;
            set => SetProperty(ref _act, value);
        }
    }
}
