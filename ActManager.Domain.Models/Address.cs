using Prism.Mvvm;

namespace ActManager.Domain.Models
{
    public class Address : BindableBase
    {
        private int _id;
        private string? _street;
        private int? _streetNumber;
        private int? _officeNumber;
        private List<Building> _building;

        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string? Street
        {
            get => _street;
            set => SetProperty (ref _street, value);
        }
        public int? StreetNumber 
        {
            get => _streetNumber;
            set => SetProperty(ref _streetNumber, value);
        }
        public int? OfficeNumber
        {
            get => _officeNumber;
            set => SetProperty(ref _officeNumber, value);
        }
        public List<Building> Buildings
        {
            get => _building;
            set => SetProperty(ref _building, value);
        }
    }
}
