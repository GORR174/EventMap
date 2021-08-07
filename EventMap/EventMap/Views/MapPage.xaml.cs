using System;
using System.Collections.Generic;
using System.Linq;
using EventMap.CustomElements;
using EventMap.Extensions;
using EventMap.Models;
using EventMap.Services;
using EventMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace EventMap.Views
{
    public partial class MapPage : ContentPage
    {
        private MapVM mapVm = new MapVM();
        
        public MapPage()
        {
            InitializeComponent();
            
            NavigationPage.SetHasNavigationBar(this, false);
            
            BindingContext = mapVm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CreateEventButton.Clicked += OnCreateButtonClicked;
            
            mapVm.LoadPins(LoadPinsFromList);

            Service<LocationService>.Instance.LoadCurrentLocation(MainMap.MoveToLocation);
        }

        private void OnCreateButtonClicked(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CreateEventPage());
            CreateEventButton.Clicked -= OnCreateButtonClicked;
        } 

        private void LoadPinsFromList(List<PinModel> pinModels)
        {
            pinModels.Select(model => new CustomPin
            {
                Label = model.Title,
                PinModel = model,
                Position = new Position(model.Latitude, model.Longitude),
                OnClick = pinModel => Navigation.PushAsync(new EventItemPage(pinModel.Dto))
            }).ForEach(MainMap.AddPin);
        }
    }
}