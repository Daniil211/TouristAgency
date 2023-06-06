using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;

namespace Application.MobileClient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPage : ContentPage
    {
        bool loaded = false;
        public RegPage()
        {
            InitializeComponent();
            object logino = "";
            object passwordo = "";
            object roleo = "";
        }



        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            if (login.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите логин", "Ок");
            }
            else if (password.Text == null || confirmPassword == null)
            {
                DisplayAlert("Неуспешно", "Введите пароль", "Ок");
            }
            else if (password.Text != confirmPassword.Text)
            {
                DisplayAlert("Неуспешно", "Неправильно повторили пароль", "Ок");
            }
            else if (phone.Text == null)
            {
                DisplayAlert("Неуспешно", "Введите телефон", "Ок");
            }
            else
            {
                string loginb = login.Text;
                App.Current.Properties["logino"] = loginb;
                string passwordb = password.Text;
                App.Current.Properties["passwordo"] = passwordb;
                App.Current.Properties["roleo"] = "User";
                //регистрация под клиентом

                DisplayAlert("Успешно", "Вы зарегистрировались как клиент", "Ок");

                MainPage page = new MainPage();
                await Navigation.PushAsync(page);
            }
        }

        private async void Authbtn_OnClickedbtn_Clicked(object sender, EventArgs e)
        {
            AuthorizationPage aw = new AuthorizationPage();
            await Navigation.PushAsync(aw);
        }
    }
}