using System.Collections.Generic;
using System.Linq;
using EventMap.DTOs;
using EventMap.Models;

namespace EventMap.Services.Implementation
{
    public class MockMapService : IMapService
    {
        public List<PinModel> GetPins()
        {
            var dtos = new List<PinDTO>
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
    }
}