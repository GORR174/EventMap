using System;
using EventMap.DTOs;
using EventMap.Models;
using EventMap.Services;
using Xamarin.Essentials;

namespace EventMap.ViewModels
{
    public class CreateEventVM
    {
        public async void CreateEvent(string name, string description, string date, Location location, Action<EventModel> onComplete)
        {
            var eventModel = await Service<IEventsService>.Instance.CreateEvent(name, description, date, location);

            onComplete(eventModel);
        }
    }
}