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
using TourAgDeskNew.Pages;

namespace Application.Desktop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// сделвть: 1.регистрацию окно доделать
    /// 2.у авторизации добавить кнопку перехода на регистрацию
    /// 3.сделать стартовой страницей авторизацию
    /// 4.добавить добавление тура, туроператора, городов, отелей
    /// 5. добавить изменение тура insale - true/false
    /// 6. добавить вывод инфы о каждом туре при нажатии на карточку
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopToursFrame.Navigate(new PopToursPage());
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AuthWindow aw = new();
            aw.Show();

        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {

            ToursWindow toursWindow = new();
            toursWindow.Show();
        }
    }
}
