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
        byte[] imageBytes;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // метод добавления
             try
             {
                if (name_tb.Text != "" && dur_tb.Text != "" && price_tb.Text != "" && des_tb.Text != "" && insale_cb.SelectedItem.ToString() != "")
                {
                    for (int i = 0; i < name_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(name_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле название тура. Невозможно добавить тур"); return; }
                    }        
                    for (int i = 0; i < dur_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(dur_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле продолжительность тура. Невозможно добавить тур"); return; }
                    }
                    for (int i = 0; i < price_tb.Text.Length; i++)
                    {
                        char ch = Convert.ToChar(price_tb.Text.Substring(i, 1));
                        if (ch == ' ')
                        { MessageBox.Show("Введен пробел в поле стоимость тура. Невозможно добавить тур"); return; }
                    }
                    bool ins = false;
                    if (insale_cb.SelectedItem.ToString() == "Да")
                    {
                        ins = true;
                    }
                    else { ins = false; }
                    decimal price;
                    try
                    {
                         price = Convert.ToDecimal(price_tb.Text);
                    }
                    catch { MessageBox.Show("Введите цену в числовом формате"); return; }
                    AddTourMet.AddTourMethod(name_tb.Text, dur_tb.Text, price, ins, imageBytes, des_tb.Text);
                }
                else
                {
                    MessageBox.Show("Заполните все поля");
                }
             }
             catch { MessageBox.Show("Ошибка сервера"); }
            
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files (*.jpg;*.png;*.gif;*.bmp)|*.jpg;*.png;*.gif;*.bmp|All Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    string imagePath = openFileDialog.FileName;
                   // string imagePath = "path/to/image.jpg";

                    using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            fileStream.CopyTo(memoryStream);
                            imageBytes = memoryStream.ToArray();
                        }
                    }
                    // base64String = WorkWithImagesMet.ConvertImgToBase64(imagePath);
                }
            }
            catch { MessageBox.Show("Неверное изображение"); }
        }
    }
}