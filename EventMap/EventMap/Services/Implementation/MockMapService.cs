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
                    Latitude = 56.8483669,
                    Longitude = 60.6508908,
                },
                new PinDTO
                {
                    Id = 0,
                    Title = "Парад утокafsa",
                    Latitude = 55.8483669,
                    Longitude = 61.6508908,
                },
            };

            return dtos
                .Select(dto => new PinModel(dto)
                {
                    Title = dto.Title,
                    Latitude = dto.Latitude,
                    Longitude = dto.Longitude,
                })
                .ToList();
        }
    }
}