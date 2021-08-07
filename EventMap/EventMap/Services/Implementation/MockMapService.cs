using System.Collections.Generic;
using System.Linq;
using EventMap.DTOs;
using EventMap.Models;
using Xamarin.Essentials;

namespace EventMap.Services.Implementation
{
    public class MockMapService : IMapService
    {
        List<PinDTO> dtos = new List<PinDTO>
        {
            new PinDTO
            {
                Id = 0,
                Title = "Парад уток",
                Date = "24.07.2021 в 21:00",
                Latitude = 56.8483669,
                Longitude = 60.6508908,
            },
            new PinDTO
            {
                Id = 1,
                Title = "Праздник мандарина",
                Date = "05.08.2021 весь день",
                Latitude = 55.8483669,
                Longitude = 61.6508908,
            },
        };

        public List<PinModel> GetPins()
        {
            return dtos
                .Select(dto => new PinModel(dto)
                {
                    Title = dto.Title,
                    Date = dto.Date,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude,
                })
                .ToList();
        }

        public PinModel CreatePin(Location location, string name, string date)
        {
            var id = dtos.Count;
            
            var pinDto = new PinDTO
            {
                Id = id,
                Title = name,
                Date = date,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
            };

            dtos.Add(pinDto);

            return new PinModel(pinDto)
            {
                Title = pinDto.Title,
                Date = pinDto.Date,
                Latitude = pinDto.Latitude,
                Longitude = pinDto.Longitude,
            };
        }
    }
}