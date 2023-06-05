using Application.Mobile.ViewModels.ViewModels.Tours;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.Mobile.Views.Views.Tours
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