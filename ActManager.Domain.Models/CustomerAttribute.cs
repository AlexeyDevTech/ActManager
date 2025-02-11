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
    public class CustomerAttribute : BindableBase
    {
        private string _attributeName;
        private string? _attributeValue;
        private Customer _customer;
        private int _id;

        public CustomerAttribute()
        {
          
        }
        [Key]
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        [ForeignKey("CustomrerID")]
        public Customer Customer
        {
            get => _customer;
            set => SetProperty(ref _customer, value);
        }
        public string AttributeName
        {
            get => _attributeName;
            set => SetProperty(ref _attributeName, value);
        }
        public string? AttributeValue
        {
            get => _attributeValue;
            set => SetProperty(ref _attributeValue, value);
        }

    }
}
