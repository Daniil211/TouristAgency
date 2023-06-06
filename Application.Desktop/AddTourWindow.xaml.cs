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
using Microsoft.Win32;
using System.IO;
using System.Windows.Shapes;

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для AddTourWindow.xaml
    /// </summary>
    public partial class AddTourWindow : Window
    {
        public AddTourWindow()
        {
            InitializeComponent();
        }
        string base64String;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //применить метод добавления
            if (name_tb.Text != "" && dur_tb.Text != "" && price_tb.Text != "" && des_tb.Text != "" && insale_cb.SelectedItem.ToString() != "")
            {
                bool ins = false;
                if (insale_cb.SelectedItem.ToString() == "Да")
                {
                    ins = true;
                }
                else { ins = false; }
                decimal price = Convert.ToDecimal(price_tb.Text);
                AddTourMet.AddTourMethod(name_tb.Text, dur_tb.Text, price, ins, base64String, des_tb.Text);
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }
        
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                base64String = WorkWithImagesMet.ConvertImgToBase64(imagePath);
            }
        }
    }
}