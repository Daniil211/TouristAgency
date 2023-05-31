using Application.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Application.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            // Создаем контекст базы данных
            var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=TourAgency;Trusted_Connection=False;TrustServerCertificate=False;";
            var options = new DbContextOptionsBuilder<TourAgencyContext>()
              .UseSqlServer(connectionString)
              .Options;

            // Создаем контекст базы данных и загружаем данные из базы данных
            using (var db = new TourAgencyContext(options))
            {
                db.Database.EnsureCreated();
                // Загружаем данные из базы данных
            }
        }
    }
}
