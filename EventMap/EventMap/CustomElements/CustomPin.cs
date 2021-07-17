using System;
using EventMap.Models;
using Xamarin.Forms.Maps;

namespace EventMap.CustomElements
{
    public class CustomPin : Pin
    {
        public PinModel PinModel { get; set; }
        public Action<PinModel> OnClick;
    }
}