using Microsoft.EntityFrameworkCore;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Models
{
    [Table("Acts")]
    public class Act : BindableBase
    {
        private int _id;
        private string _name;
        private string _fileName;
        
        [Key]
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        [ForeignKey("BuildingID")]
        public Building? Building { get; set; }
        public IEnumerable<FileName>? Files { get; set; }
        public IEnumerable<Goal>? Goals { get; set; }
    }
}
