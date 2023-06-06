using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System;
using System.Linq;
using Application.MobileClient.Models;
using Application.MobileClient.Services;
using Application.MobileClient.Views;
using Xamarin.Forms;

namespace Application.MobileClient
{
    public partial class MainPage : ContentPage
    {
        private readonly IUserService _userService;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(ApiUserService userService, IServiceScopeFactory serviceScopeFactory)
        {
            _userService = userService;
            _serviceScopeFactory = serviceScopeFactory;
            TextBoxLogin.Text = "user1";
            TextBoxPassword.Text = "user1";
            Test();
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {
            var users = await _userService.GetUsers();

            bool any = false;
            foreach (var u in users)
            {
                if (u != null && u.UserName == TextBoxLogin.Text && u.Password == TextBoxPassword.Text)
                {
                    any = true;
                    if (any)
                    {
                        await DisplayAlert("Уведомление", "+", "Ok");
                        var navigationPage = new NavigationPage(new Tours());
                        await navigationPage.PushAsync(new Tours());
                    }
                    break;
                }
                else
                {
                    await DisplayAlert("Уведомление", "Неверный логин или пароль", "Ok");
                }
            }
        }

        private async void Test()
        {
            var result = await _userService.GetUsers();
            // Дополнительная логика
        }
    }
}
