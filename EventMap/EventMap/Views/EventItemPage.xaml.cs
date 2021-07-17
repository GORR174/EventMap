using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMap.DTOs;
using EventMap.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EventItemPage : ContentPage
    {
        private EventItemVM viewModel = new EventItemVM();

        private PinDTO pinDto;
        
        public EventItemPage(PinDTO pinDto)
        {
            InitializeComponent();

            SetLoading(true);
            
            this.pinDto = pinDto;
        }

        private void SetLoading(bool isLoading)
        {
            ProgressBar.IsVisible = isLoading;
            ProgressBar.IsRunning = isLoading;
            TitleView.IsVisible = !isLoading;
            Description.IsVisible = !isLoading;
            Date.IsVisible = !isLoading;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            viewModel.GetEventInfo(pinDto.Id, model =>
            {
                Title = model.Title;
                TitleView.Text = model.Title;
                Description.Text = model.Description;
                Date.Text = model.Date;
                
                SetLoading(false);
            });
        }
    }
}