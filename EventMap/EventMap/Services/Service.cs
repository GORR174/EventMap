namespace EventMap.Services
{
    public class Service<T>
    {
        public static T Instance { get; private set; }
        
        public static void RegisterService(T service)
        {
            Instance = service;
        }
    }
}