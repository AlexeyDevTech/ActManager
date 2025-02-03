using Prism.Mvvm;

namespace ActManager.Domain.Models
{
    public class Building : BindableBase
    {
        private int _id;
        private string? _name;
        private Address _addressInst;
        private IEnumerable<Act> _acts;

        public int ID
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public Address AddressInst
        {
            get => _addressInst;
            set => SetProperty(ref _addressInst, value);
        }
        public IEnumerable<Act> Acts
        {
            get => _acts;
            set => SetProperty(ref _acts, value);
        }
    }
}
