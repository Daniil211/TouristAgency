﻿using System;
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
        public AdminWindow()
        {
            InitializeComponent();
            db = new TourAgencyContext();
            var tbOrders = from ord in db.Orders
                           join us in db.Clients on ord.ClientId equals us.ClientId
                           join tour in db.Tours on ord.TourId equals tour.TourId
                           join op in db.TourOperators on ord.ToutOperatorId equals op.OperatorId

                           select new
                           {
                               Номер_заказа = ord.OrderId,
                               ФИО_клиента = us.Fio,
                               Номер_телефона = us.Phone,
                               Название_тура = tour.TourName,
                               ФИО_туроператора = op.Fio,

                           };
            DataGridOrders.ItemsSource = tbOrders.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var num = from n in db.Orders select n.OrderId;
            num_cb.ItemsSource = num.ToList();
            var men = from m in db.TourOperators
                      select m.Fio;
            cbmen.ItemsSource = men.ToList();
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            if (num_cb.SelectedItem.ToString() != "" && cbmen.SelectedItem.ToString() != "")
            {
                using (TourAgencyContext fcon = new TourAgencyContext())
                {
                    var num = num_cb.SelectedItem.ToString();
                    var men = cbmen.SelectedItem.ToString();
                    int meni = fcon.TourOperators.Where(c => c.Fio == men).FirstOrDefault().OperatorId;
                    var zakaz = fcon.Orders.Where(c => c.OrderId.ToString() == num).FirstOrDefault();
                    zakaz.ToutOperatorId = meni;
                    fcon.SaveChanges();
                    MessageBox.Show("Заказ изменен");
                    var tbOrders = from ord in db.Orders
                                   join us in db.Clients on ord.ClientId equals us.ClientId
                                   join tour in db.Tours on ord.TourId equals tour.TourId
                                   join op in db.TourOperators on ord.ToutOperatorId equals op.OperatorId

                                   select new
                                   {
                                       Номер_заказа = ord.OrderId,
                                       ФИО_клиента = us.Fio,
                                       Номер_телефона = us.Phone,
                                       Название_тура = tour.TourName,
                                       ФИО_туроператора = op.Fio,

                                   };
                    DataGridOrders.ItemsSource = tbOrders.ToList();
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void men_btn_Click(object sender, RoutedEventArgs e)
        {
            AdminsWindow aw = new AdminsWindow();
            aw.Show();
        }
    }
}
