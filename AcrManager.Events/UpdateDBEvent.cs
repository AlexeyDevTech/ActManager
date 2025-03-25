using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Events
{
    public class UpdateDBData
    {
        //имя таблицы
        public string TableName { get; set; }
        //экземпляр объекта 
        public object Instance { get; set; }
    }
    public class UpdateDBEvent : PubSubEvent<UpdateDBData> { }
}
