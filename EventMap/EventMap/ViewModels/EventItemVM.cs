using System;
using EventMap.DTOs;
using EventMap.Models;
using EventMap.Services;

namespace EventMap.ViewModels
{
    public class EventItemVM
    {
        public async void GetEventInfo(int eventId, Action<EventModel> onComplete)
        {
            var eventModel = await Service<IEventsService>.Instance.GetEventInfo(eventId);

            onComplete(eventModel);
        }
    }
}