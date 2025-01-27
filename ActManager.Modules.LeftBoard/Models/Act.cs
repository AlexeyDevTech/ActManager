using Prism.Mvvm;
using System;

namespace ActManager.Modules.LeftBoard.Models
{
    public class Act : BindableBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
