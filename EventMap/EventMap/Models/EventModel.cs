using EventMap.DTOs;

namespace EventMap.Models
{
    public class EventModel
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        
        public EventDTO Dto { get; }

        public EventModel(EventDTO dto)
        {
            Dto = dto;
        }
    }
}