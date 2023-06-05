using Application.MobileClient.Views.Views.Tours;
using Xamarin.Forms;

namespace Application.MobileClient
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddTour), typeof(AddTour));
            Routing.RegisterRoute(nameof(TourDetails), typeof(TourDetails));
        }

    }
}
