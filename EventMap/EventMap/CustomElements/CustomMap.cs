using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace EventMap.CustomElements
{
    public class CustomMap : Map
    {
        public List<CustomPin> CustomPins { get; set; }

        public CustomMap()
        {
            CustomPins = new List<CustomPin>();
        }

        public void AddPin(CustomPin pin)
        {
            Pins.Add(pin);
            CustomPins.Add(pin);
        }
    }
}