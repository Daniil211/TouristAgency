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
