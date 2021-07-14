using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using Map = Xamarin.Forms.Maps.Map;

namespace EventMap.Extensions
{
    public static class MapExtensions
    {
        public static void MoveToLocation(this Map map, Location location)
        {
            map.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(location.Latitude, location.Longitude),
                Distance.FromKilometers(0.5)
            ));
        }
    }
}