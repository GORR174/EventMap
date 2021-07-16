using EventMap.DTOs;

namespace EventMap.Models
{
    public class PinModel
    {
        public string Title { get; set; }
        public string Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public PinDTO Dto { get; }

        public PinModel(PinDTO dto)
        {
            Dto = dto;
        }
    }
}