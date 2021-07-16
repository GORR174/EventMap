using System.Collections.Generic;
using EventMap.Models;

namespace EventMap.Services
{
    public interface IMapService
    {
        List<PinModel> GetPins();
    }
}