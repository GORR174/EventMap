using System.Collections.Generic;
using System.Linq;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using Android.Widget;
using EventMap.Android;
using EventMap.CustomElements;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace EventMap.Android
{
    public class CustomMapRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        private List<CustomPin> customPins;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap) e.NewElement;
                customPins = formsMap.CustomPins;
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnInfoWindowClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();

            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(Color.Goldenrod.GetHue()));

            return marker;
        }

        public View GetInfoContents(Marker marker)
        {
            var inflater = Context.GetSystemService(global::Android.Content.Context.LayoutInflaterService) as LayoutInflater;
            if (inflater != null)
            {
                View view;

                view = inflater.Inflate(Resource.Layout.MapInfoWindow, null);
                
                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoDate = view.FindViewById<TextView>(Resource.Id.InfoWindowDate);

                infoTitle.Text = marker.Title;
                infoDate.Text = customPins.First(pin => pin.Label == marker.Title).PinModel.Date;

                return view;
            }

            return null;
        }

        public View GetInfoWindow(Marker marker)
        {
            return null;
        }
        
        private void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var pin = customPins.First(pin => pin.Label == e.Marker.Title);

            pin.OnClick(pin.PinModel);
        }
    }
}