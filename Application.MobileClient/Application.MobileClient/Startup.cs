using Microsoft.Extensions.DependencyInjection;
using System;
using Application.MobileClient.Services.Services.Tour;
using Application.MobileClient.ViewModels.ViewModels.Tours;

namespace Application.MobileClient
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services
            services.AddHttpClient<ITourService, ApiTourService>(c => 
            {
                c.BaseAddress = new Uri("http://10.0.2.2:13190/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<ToursViewModel>();
            services.AddTransient<AddTourViewModel>();
            services.AddTransient<TourDetailsViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
