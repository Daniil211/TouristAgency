using Application.MobileClient.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.MobileClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToursForClient : ContentPage
    {
        private readonly ToursViewModel _toursViewModel;

        public ToursForClient()
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
