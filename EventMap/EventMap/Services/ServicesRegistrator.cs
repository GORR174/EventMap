namespace EventMap.Services
{
    public class ServicesRegistrator
    {
        public static void RegisterServices(bool isFake)
        {
            Service<LocationService>.RegisterService(new LocationService());
        }
    }
}