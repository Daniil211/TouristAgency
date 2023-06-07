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
using Application.Desktop.Methods;
using Microsoft.Win32;

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для AdminsWindow.xaml
    /// </summary>
    public partial class AdminsWindow : Window
    {
        TourAgencyContext db;
        string base64String;
        public AdminsWindow()
        {
            InitializeComponent();
            try
            {
                db = new TourAgencyContext();
                var tbOrders = from men in db.TourOperators
                               select new
                               {
                                   IdMenedger = men.OperatorId,
                                   FIOMenedger = men.Fio,
                                   AgeMenedger = men.Age,
                               };
                DataGridMen.ItemsSource = tbOrders.ToList();
            }
            catch { MessageBox.Show("Ошибка сервера"); }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imagePath = openFileDialog.FileName;
                    base64String = WorkWithImagesMet.ConvertImgToBase64(imagePath);
                }
            }
           catch { MessageBox.Show("Ошибка сервера"); }
        }

        private void save_btn_Click(object sender, RoutedEventArgs e)
        {
            // метод добавления
            try
            {
                if (tb1.Text != "" && tb2.Text != "" && tb3.Text != "")
                {
                    for (int i = 0; i < tb1.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(tb1.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле ФИО. Невозможно добавить пользователя"); return; }
                    } 
                    for (int i = 0; i < tb2.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(tb2.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле возраст. Невозможно добавить пользователя"); return; }
                    }
                    for (int i = 0; i < tb3.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(tb3.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле резюме. Невозможно зарегистрироваться"); return; }
                    }
                    if (Convert.ToInt32(tb2.Text) <= 18 && Convert.ToInt32(tb2.Text) >= 82)
                    {
                        MessageBox.Show("Введен некорректный возраст. Невозможно добавить туроператора"); return;
                    }
                    AddMenedgerMet.AddMenedgerMethod(tb1.Text, Convert.ToInt32(tb2.Text), tb3.Text, base64String);
                    var tbOrders = from men in db.TourOperators
                                   select new
                                   {
                                       IdMenedger = men.OperatorId,
                                       FIOMenedger = men.Fio,
                                       AgeMenedger = men.Age,
                                   };
                    DataGridMen.ItemsSource = tbOrders.ToList();
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка сервера");
            }
        }
    }
}