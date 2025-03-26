using Prism.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActManager.Events
{
    public class NotificatonData
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime EventDate { get; set; }
        public object Instance { get; set; }
    }

    public class NotificationEvent : PubSubEvent<NotificatonData>
    {
    }
}
