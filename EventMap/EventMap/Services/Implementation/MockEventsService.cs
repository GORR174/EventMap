using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EventMap.DTOs;
using EventMap.Models;
using Xamarin.Essentials;

namespace EventMap.Services.Implementation
{
    public class MockEventsService : IEventsService
    {
        private Dictionary<int, EventDTO> dtos = new Dictionary<int, EventDTO>
        {
            {
                0, new EventDTO
                {
                    Id = 0,
                    Title = "Парад уток",
                    Date = "24.07.2021 в 21:00",
                    Description = "Увлекательный и незабываемый парад уток в Екатеринбурге. Приходи и мы тебя накормим пшеном бесплатно!!!!"
                }
            },
            {
                1, new EventDTO
                {
                    Id = 1,
                    Title = "Праздник мандарина",
                    Date = "05.08.2021 весь день",
                    Description = "Любишь мандарины? Приходи к нам! Тебя ждёт очень увлекательный квест поиска мандаринов в кустах Екатеринбурга. Зови друзей и ешь мандарины вместе!"
                }
            },
        };

        public async Task<EventModel> GetEventInfo(int eventId)
        {
            await Task.Delay(2000);
            
            var dto = dtos[eventId];

            return new EventModel(dto)
            {
                Title = dto.Title,
                Date = dto.Date,
                Description = dto.Description
            };
        }

        public async Task<EventModel> CreateEvent(string name, string description, string date, Location location)
        {
            await Task.Delay(1000);
            
            var id = dtos.Count;
            dtos.Add(id, new EventDTO
            {
                Date = date,
                Description = description,
                Title = name,
                Id = id
            });
            
            var dto = dtos[id];

            Service<IMapService>.Instance.CreatePin(location, name, date);

            return new EventModel(dto)
            {
                Title = dto.Title,
                Date = dto.Date,
                Description = dto.Description
            };
        }
    }
}