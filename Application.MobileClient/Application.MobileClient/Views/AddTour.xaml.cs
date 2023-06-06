using Application.MobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTour : ContentPage
    {
        public AddTour()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<AddTourViewModel>();
        }
    }
}