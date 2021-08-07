using System.Threading.Tasks;
using EventMap.Models;
using Xamarin.Essentials;

namespace EventMap.DTOs
{
    public interface IEventsService
    {
        Task<EventModel> GetEventInfo(int eventId);
        Task<EventModel> CreateEvent(string name, string description, string date, Location location);
    }
}