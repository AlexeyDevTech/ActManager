using Prism.Events;

namespace ActManager.Events.Buildings
{
    public class LocationData
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
    public class LocationUpdateEvent : PubSubEvent<LocationData> { }
}
