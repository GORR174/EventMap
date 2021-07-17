using System.Threading.Tasks;
using EventMap.Models;

namespace EventMap.DTOs
{
    public interface IEventsService
    {
        Task<EventModel> GetEventInfo(int eventId);
    }
}