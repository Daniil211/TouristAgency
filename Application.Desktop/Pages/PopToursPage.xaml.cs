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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application.Database;
using Application.Database.Models;
using Application.Desktop;

namespace TourAgDeskNew.Pages
{
    /// <summary>
    /// Interaction logic for PopToursPage.xaml
    /// </summary>
    public partial class PopToursPage : Page
    {
        private int Id { get; }
        public PopToursPage(int id)
        {
            InitializeComponent();
            Id = id;
        }

        private void Btn_MakeOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = (sender as Button).DataContext as Order;
            OrderWindow orderWindow = new OrderWindow(Id);
            orderWindow.Show();
        }
    }
}
