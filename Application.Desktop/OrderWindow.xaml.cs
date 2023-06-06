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
using Microsoft.EntityFrameworkCore;

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        TourAgencyContext db;
        private int Id { get; }
        public OrderWindow(int id)
        {
            InitializeComponent();
            db = new TourAgencyContext();
            var currentTours = from ct in db.Tours select ct.TourName;
            Tour_cb.ItemsSource = currentTours.ToList();
            Id = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Id.ToString());
            Order ord = new Order();
            var curtourdb = db.Tours.Where(x => x.TourName == Tour_cb.SelectedItem.ToString()).FirstOrDefault().TourId;
            ord.TourId = curtourdb;
            //тут добавить потом фиксацию айдишника при авторизации
            ord.UserId = Id;
            db.Orders.Add(ord);
            db.SaveChanges();
            MessageBox.Show("Заявка оставлена");
        }
    }
}


