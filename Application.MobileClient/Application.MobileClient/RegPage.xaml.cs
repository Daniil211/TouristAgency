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
            try
            {
                if (login.Text.Length > 40)
                {
                    DisplayAlert("Невозможно зарегистрироваться", "Введено длинное в поле логин", "Ок"); return;
                }
                if (password.Text.Length > 40)
                {
                    DisplayAlert("Невозможно зарегистрироваться", "Введено длинное в поле пароль", "Ок"); return;
                }
                if (confirmPassword.Text.Length > 40)
                {
                    DisplayAlert("Невозможно зарегистрироваться", "Введено длинное в поле пароль", "Ок"); return;
                }
                if (phone.Text.Length > 12)
                {
                    DisplayAlert("Невозможно зарегистрироваться", "Введено длинное в телефон", "Ок"); return;
                }
                for (int i = 0; i < login.Text.Length; i++)
                {
                    char ch = Convert.ToChar(login.Text.Substring(i, 1));
                    if (ch == ' ')
                    { DisplayAlert("Невозможно зарегистрироваться", "Введен пробел в поле логин", "Ок"); return; }
                }
                for (int i = 0; i < password.Text.Length; i++)
                {
                    char ch = Convert.ToChar(password.Text.Substring(i, 1));
                    if (ch == ' ')
                    { DisplayAlert("Невозможно зарегистрироваться", "Введен пробел в поле пароль", "Ок"); return; }
                }
                for (int i = 0; i < Convert.ToString(phone).Length; i++)
                {
                    char ch = Convert.ToChar(Convert.ToString(phone).Substring(i, 1));
                    if (ch >= '0' && ch <= '9')
                    {
                        continue;
                    }
                    else
                    { DisplayAlert("Невозможно зарегистрироваться", "Введите телефон в числовом формате", "Ок"); return; }
                }
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
            catch { DisplayAlert("Неуспешно", "Ошибка сервера", "Ок"); }
        }

        private async void Authbtn_OnClickedbtn_Clicked(object sender, EventArgs e)
        {
            AuthorizationPage aw = new AuthorizationPage();
            await Navigation.PushAsync(aw);
        }
    }
}