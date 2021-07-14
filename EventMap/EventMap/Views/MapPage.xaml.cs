using System;
using EventMap.Extensions;
using EventMap.Services;
using Xamarin.Forms;

namespace EventMap.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Service<LocationService>.Instance.LoadCurrentLocation(MainMap.MoveToLocation);
        }
    }
}