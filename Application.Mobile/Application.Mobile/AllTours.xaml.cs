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
    public partial class AllTours : ContentPage
    {
        public AllTours()
        {
            InitializeComponent();
        }

        private async void ButtonMain_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}