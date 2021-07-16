using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using EventMap.Android;
using EventMap.CustomElements;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace EventMap.Android
{
    public class CustomMapRenderer : MapRenderer
    {
        private List<CustomPin> customPins;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                
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
            
            
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();

            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetIcon(BitmapDescriptorFactory.DefaultMarker(Color.Goldenrod.GetHue()));

            return marker;
        }
    }
}