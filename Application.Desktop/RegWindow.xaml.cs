using System;
using System.Collections.Generic;
using System.Data;
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
using Application.Desktop.Methods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        TourAgencyContext db;
        public RegWindow()
        {
            InitializeComponent();
            db = new TourAgencyContext();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //здесь обработчик регистрации
            if (login_tb.Text != "" && pass_tb.Text != "" && pass2_tb.Text != "" && fio_tb.Text != "" && date_tb != null && phone_tb.Text != null)
            {
                if (pass_tb.Text == pass2_tb.Text)
                {
                    if (DateTime.ParseExact(date_tb.Text, "dd.MM.yyyy", null) < new DateTime(1941, 1, 1))
                    {
                        MessageBox.Show("Дата не может быть меньше 1941 года");
                        return;
                    }
                    if (pass_tb.Text.Length < 3)
                    {
                        MessageBox.Show("Пароль должен содержать не менее 3 символов");
                        return;
                    }
                    RegMet.RegMethod(login_tb.Text, pass_tb.Text, fio_tb.Text, DateTime.ParseExact(date_tb.Text, "dd.MM.yyyy", null), phone_tb.Text);
                }
                else
                {
                    MessageBox.Show("Повторите пароль правильно");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //здесь переход на вход
            AuthWindow aw = new();
            this.Close();
            aw.Show();
        }
    }
}
