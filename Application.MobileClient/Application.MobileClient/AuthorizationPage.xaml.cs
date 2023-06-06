using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.MobileClient.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Application.MobileClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        private async void regbtn_Clicked(object sender, EventArgs e)
        {
            RegPage page = new RegPage();
            await Navigation.PushAsync(page);
        }

        private async void kabinetButton_Clicked(object sender, EventArgs e)
        {
            string log = App.Current.Properties["logino"].ToString();
            string pass = App.Current.Properties["passwordo"].ToString();
            string role = App.Current.Properties["roleo"].ToString();
            if (login.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите логин", "Ок");
            }
            else if (password.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите пароль", "Ок");
            }
            else
            {
                if (login.Text == "Admin" && password.Text == "Admin")
                {
                    DisplayAlert("Успешно", "Вы вошли как админ", "Ок");
                    Tours page = new Tours();
                    await Navigation.PushAsync(page);
                }
                else if (role == "User")
                {
                    DisplayAlert("Успешно", "Вы вошли как клиент", "Ок");
                    MainPage page = new MainPage();
                    await Navigation.PushAsync(page);
                }
            }
        }
    }
}