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
            
            BindingContext = mapVm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            mapVm.LoadPins(LoadPinsFromList);

            Service<LocationService>.Instance.LoadCurrentLocation(MainMap.MoveToLocation);
        }

        private void LoadPinsFromList(List<PinModel> pinModels)
        {
            pinModels.Select(model => new CustomPin
            {
                Label = model.Title,
                PinModel = model,
                Position = new Position(model.Latitude, model.Longitude),
            }).ForEach(MainMap.AddPin);
        }
    }
}