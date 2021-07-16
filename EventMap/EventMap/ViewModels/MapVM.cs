using System;
using System.Collections.Generic;
using System.ComponentModel;
using EventMap.Models;
using EventMap.Services;

namespace EventMap.ViewModels
{
    public class MapVM : INotifyPropertyChanged
    {
        public List<PinModel> Pins { get; set; }

        public void LoadPins(Action<List<PinModel>> onLoad)
        {
            Pins = Service<IMapService>.Instance.GetPins();
            onLoad(Pins);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}