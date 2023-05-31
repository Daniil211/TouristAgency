using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application.Database;
using Application.Database.Models;

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для AdminsWindow.xaml
    /// </summary>
    public partial class AdminsWindow : Window
    {
        TourAgencyContext db;
        public AdminsWindow()
        {
            InitializeComponent();
            db = new TourAgencyContext();
            var tbOrders = from men in db.TourOperators
                           select new
                           {
                               Менеджер = men.Fio,
                           };
            DataGridMen.ItemsSource = tbOrders.ToList();
        }

    }
}