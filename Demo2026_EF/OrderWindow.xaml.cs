using Demo2026_EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Demo2026_EF
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        Demo2026_EFContext db = new Demo2026_EFContext();
        ObservableCollection<Order> orders = new ObservableCollection<Order>();
        
        public OrderWindow()
        {
            InitializeComponent();

            db.Orders.Include(o => o.Punkt).Load();
            orders = db.Orders.Local.ToObservableCollection();

            OrdersList.ItemsSource = orders;

            if (LoginUser.role == "Менеджер")
            {
                NoManager.Visibility = Visibility.Collapsed;
            }

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Order o = new Order();
            AddOrderWindow w = new AddOrderWindow();
            
            w.ListUser.ItemsSource = db.Users.ToList();
            w.ListPunkt.ItemsSource = db.Punkt.ToList();
            w.ListProduct.ItemsSource = db.Products.ToList();

            w.DataContext = o;


            if (w.ShowDialog() == true)
            {
                orders.Add(o);
                db.SaveChanges();
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (LoginUser.role == "Менеджер")
                return;

            if ((sender as StackPanel).DataContext is Order o)
            {
                AddOrderWindow w = new AddOrderWindow();
                
                w.ListUser.ItemsSource = db.Users.ToList();
                w.ListPunkt.ItemsSource = db.Punkt.ToList();
                w.ListProduct.ItemsSource = db.Products.ToList();

                w.DataContext = o;
                w.ShowDialog();

                db.SaveChanges();
            }
        }
    }
}
