using Application.MobileClient.ViewModels.ViewModels.Tours;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.MobileClient.Views.Views.Tours
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