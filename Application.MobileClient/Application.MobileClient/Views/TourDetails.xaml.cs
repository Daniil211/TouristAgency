using Application.MobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TourDetails : ContentPage
    {
        public TourDetails()
        {
            InitializeComponent();

            BindingContext = Startup.Resolve<TourDetailsViewModel>();
        }
    }
}