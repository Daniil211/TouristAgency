using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MobileClient.Views;
using Xamarin.Forms;

namespace Application.MobileClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ButtonPod_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Tours());
        }
        private async void ButtonAll_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AllTours());
        }

        private async void ButtonOrd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new OrderList());
        }
    }
}
