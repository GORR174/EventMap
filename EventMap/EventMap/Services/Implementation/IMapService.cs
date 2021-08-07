using System.Collections.Generic;
using EventMap.Models;
using Xamarin.Essentials;

namespace EventMap.Services
{
    public interface IMapService
    {
        List<PinModel> GetPins();
        PinModel CreatePin(Location location, string name, string date);
    }
}