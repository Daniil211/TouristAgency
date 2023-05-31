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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        TourAgencyContext db;
        public OrderWindow()
        {
            InitializeComponent();
            using var db = new TourAgencyContext();
            var currentTours = db.Tours.ToList();
            Tour_cb.ItemsSource = currentTours;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order ord = new Order();
                Client client = new Client();
                client.Fio = FIO_tb.Text;
                client.DateOfBirth = Convert.ToDateTime(DateOfB_tb.Text);
                client.Phone = Phone_tb.Text;
                db.Clients.Add(client);
                db.SaveChanges();
                // MessageBox.Show("User added");
                if (Tour_cb.SelectedIndex > 0) { ord.TourId = Tour_cb.SelectedIndex; }

                var selectedClient = db.Clients.Where(p => p.Fio == FIO_tb.Text);
                foreach (Client clientt in selectedClient)
                {
                    ord.ClientId = clientt.ClientId;
                }
                db.Orders.Add(ord);
                db.SaveChanges();
                MessageBox.Show("Заявка оставлена");
            }
            catch { MessageBox.Show("Заполните все поля"); }

        }
    }
}


