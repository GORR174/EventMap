namespace EventMap.Services
{
    public class Service<T> where T: IService
    {
        public static T Instance { get; private set; }
        
        public static void RegisterService(T service)
        {
            Instance = service;
        }
    }
}