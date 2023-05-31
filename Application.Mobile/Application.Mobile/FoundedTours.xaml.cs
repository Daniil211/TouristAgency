using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoundedTours : ContentPage
    {
        public FoundedTours()
        {
            InitializeComponent();
        }
        private async void ButtonMain_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}