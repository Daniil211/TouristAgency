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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        TourAgencyContext db;
        private int Id { get; }
        public AdminWindow(int id)
        {
            InitializeComponent();
            try
            {
                db = new TourAgencyContext();
                var ord = from o in db.Orders
                          join us in db.Users on o.UserId equals us.Id
                          join t in db.Tours on o.TourId equals t.TourId
                          join m in db.TourOperators on o.TourOperatorId equals m.OperatorId
                          select new
                          {
                              IdOrder = o.OrderId,
                              FIOClient = us.Username,
                              Phone = us.Phone,
                              TourName = t.TourName,
                              FIOMenedger = m.Fio,
                          };
                DataGridOrders.ItemsSource = ord.ToList();
                Id = id;
            }
            catch { MessageBox.Show("ошибка сервера"); }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
            var num = from n in db.Orders select n.OrderId;
            num_cb.ItemsSource = num.ToList();
            var men = from m in db.TourOperators
                      select m.Fio;
            cbmen.ItemsSource = men.ToList();
            }
            catch { MessageBox.Show("ошибка сервера"); }
        }
        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (num_cb.SelectedItem.ToString() != "" && cbmen.SelectedItem.ToString() != "")
                {
                    using (TourAgencyContext fcon = new TourAgencyContext())
                    {
                        var num = num_cb.SelectedItem.ToString();
                        var men = cbmen.SelectedItem.ToString();
                        int meni = fcon.TourOperators.Where(c => c.Fio == men).FirstOrDefault().OperatorId;
                        var zakaz = fcon.Orders.Where(c => c.OrderId.ToString() == num).FirstOrDefault();
                        zakaz.TourOperatorId = meni;
                        fcon.SaveChanges();
                        MessageBox.Show("Туроператор изменен");
                        var ord = from o in db.Orders
                                  join us in db.Users on o.UserId equals us.Id
                                  join t in db.Tours on o.TourId equals t.TourId
                                  join m in db.TourOperators on o.TourOperatorId equals m.OperatorId
                                  select new
                                  {
                                      IdOrder = o.OrderId,
                                      FIOClient = us.Username,
                                      Phone = us.Phone,
                                      TourName = t.TourName,
                                      FIOMenedger = m.Fio,
                                  };
                        DataGridOrders.ItemsSource = ord.ToList();
                    }
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch { MessageBox.Show("ошибка сервера"); }
        }
        private void men_btn_Click(object sender, RoutedEventArgs e)
        {
            AdminsWindow aw = new AdminsWindow();
            aw.Show();
        }
        private void toursadd_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTourWindow atw = new();
            atw.Show();
        }
    }
}