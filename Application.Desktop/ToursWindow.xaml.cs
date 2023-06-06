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
    /// Логика взаимодействия для ToursWindow.xaml
    /// </summary>
    public partial class ToursWindow : Window
    {
        public ToursWindow()
        {
            InitializeComponent();
            using var db = new TourAgencyContext();
            var current = db.Tours.ToList();
       
          /*  var ord = from o in db.Tours
                      select new
                      {
                          Id = o.TourId,
                          Imagg = o.Image,
                          Phone = us.Phone,
                          TourName = t.TourName,
                          FIOMenedger = m.Fio,
                      };*/
            LViewTours.ItemsSource = current;
           // LViewTours.ItemsSource = ord.ToList();
        }
        private void Btn_MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new();
            orderWindow.Show();
        }
    }
}
