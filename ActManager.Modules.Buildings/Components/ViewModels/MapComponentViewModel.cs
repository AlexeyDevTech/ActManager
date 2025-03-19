using ActManager.Events.Buildings;
using GMap.NET;
using GMap.NET.MapProviders;
using Prism.Events;
using Prism.Mvvm;
using System;

namespace ActManager.Modules.Buildings.Components.ViewModels
{
    public class MapComponentViewModel : BindableBase, IDisposable
	  {

        private GMapProvider _gMapProvider;
        private PointLatLng _mapPosition;
        private double _zoomLevel;
        private IEventAggregator _eventAggregator;

        public GMapProvider MapProvider
        {
            get => _gMapProvider;
            set => SetProperty(ref _gMapProvider, value);
        }
        public PointLatLng MapPosition
        {
            get => _mapPosition;
            set => SetProperty(ref _mapPosition, value);    
        }
        public double ZoomLevel
        {
            get => _zoomLevel;
            set => SetProperty(ref _zoomLevel, value);
        }

        public MapComponentViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            MapProvider = OpenStreetMapProvider.Instance;
            MapPosition = new PointLatLng(57.591468, 39.862795);
            ZoomLevel = 15;

            Initialize();
        }

        private void Initialize()
        {
            _eventAggregator.GetEvent<LocationUpdateEvent>().Subscribe(UpdateLocation);
        }

        private void UpdateLocation(LocationData data)
        {
            MapPosition = new PointLatLng(data.Latitude, data.Longitude);
        }

        public void Dispose()
        {
            GMaps.Instance.CancelTileCaching();
            GC.SuppressFinalize(GMaps.Instance);
        }
    }
}
