using EventMap.DTOs;
using EventMap.Services.Implementation;

namespace EventMap.Services
{
    public class ServicesRegistrator
    {
        public static void RegisterServices(bool isFake)
        {
            Service<LocationService>.RegisterService(new LocationService());
            Service<IMapService>.RegisterService(new MockMapService());
            Service<IEventsService>.RegisterService(new MockEventsService());
        }
    }
}