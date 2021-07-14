using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EventMap.Services
{
    public class LocationService : IService
    {
        public async void LoadCurrentLocation(Action<Location> onLoad)
        {
            var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            var cts = new CancellationTokenSource();
            var currentLocation = await Geolocation.GetLocationAsync(request, cts.Token);
            
            onLoad(currentLocation);
        }
    }
}