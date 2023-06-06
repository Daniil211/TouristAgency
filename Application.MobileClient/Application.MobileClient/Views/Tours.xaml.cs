using Application.MobileClient.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Application.MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tours : ContentPage
    {
        private readonly ToursViewModel _toursViewModel;

        public Tours()
        {
            InitializeComponent();

            _toursViewModel = Startup.Resolve<ToursViewModel>();
            BindingContext = _toursViewModel;
        }
        protected override void OnAppearing()
        {
            _toursViewModel?.PopulateTours();
        }
    }
}