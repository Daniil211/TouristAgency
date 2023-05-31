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
            //Переделал под .net 7
            //var currentTours = TourAgencyContext.GetContext().Tours.ToList();
            //LViewTours.ItemsSource = currentTours;
            using var db = new TourAgencyContext();
            var currentTours = db.Tours.ToList();
            LViewTours.ItemsSource = currentTours;
        }
        private void Btn_MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            Order? order = (sender as Button).DataContext as Order;
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
        }
    }
}
