using EventMap.Services;
using EventMap.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EventMap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateEventPage : ContentPage
    {
        private CreateEventVM viewModel = new CreateEventVM();

        private Location location;

        public CreateEventPage()
        {
            InitializeComponent();

            SetLoading(true);

            LoadLocation();
        }

        private void LoadLocation()
        {
            Service<LocationService>.Instance.LoadCurrentLocation(location =>
            {
                this.location = location;
                SetLoading(false);
            });
        }

        private void SetLoading(bool isLoading)
        {
            ProgressBar.IsVisible = isLoading;
            ProgressBar.IsRunning = isLoading;
            Name.IsVisible = !isLoading;
            Description.IsVisible = !isLoading;
            Date.IsVisible = !isLoading;
            NameInput.IsVisible = !isLoading;
            DescriptionInput.IsVisible = !isLoading;
            DateInput.IsVisible = !isLoading;
            CreateButton.IsVisible = !isLoading;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            CreateButton.Clicked += (sender, args) =>
            {
                SetLoading(true);
                
                viewModel.CreateEvent(NameInput.Text, DescriptionInput.Text, DateInput.Text, location,
                    model => Navigation.PopAsync());
            };
        }
    }
}