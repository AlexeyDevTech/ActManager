using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Domain.Models
{
    public class Customer : BindableBase
    {

        public Customer() { }

        private string _firstName;
        private string _secondName;
        private string _thirdName;
        private int _id;
        private List<CustomerAttribute>? _attributes;
        private List<Goal>? _goals;

        [Key]
        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }
        public string SecondName
        {
            get => _secondName;
            set => SetProperty(ref _secondName, value);
        }
        public string ThirdName
        {
            get => _thirdName;
            set => SetProperty(ref _thirdName, value);
        }
        public List<CustomerAttribute>? Attributes
        {
            get => _attributes;
            set => SetProperty(ref _attributes, value);
        }
        public List<Goal>? Goals
        {
            get => _goals;
            set => SetProperty(ref _goals, value);
        }
    }
}
