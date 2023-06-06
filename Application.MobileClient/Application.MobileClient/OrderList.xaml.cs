using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.MobileClient
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderList : ContentPage
	{
		public OrderList ()
		{
			InitializeComponent ();
		}
        private async void ButtonMain_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}