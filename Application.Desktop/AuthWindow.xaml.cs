using Application.Database;
using Application.Desktop.Methods;
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

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        TourAgencyContext db;
        public AuthWindow()
        {
            InitializeComponent();
            db= new TourAgencyContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login_tb.Text != "" && pass_tb.Text != "")
            {
                    AuthMet.AuthMethod(login_tb.Text, pass_tb.Text);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RegWindow rw = new();
            rw.Show();
        }
    }
}
