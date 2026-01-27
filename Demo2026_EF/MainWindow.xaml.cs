using Demo2026_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Demo2026_EF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Demo2026_EFContext db = new Demo2026_EFContext();

        ObservableCollection<Product> products = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();

            db.Products.Load();
            products = db.Products.Local.ToObservableCollection();
            ProductsList.ItemsSource = products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            AddProductWindow w = new AddProductWindow();
            w.DataContext = p;
            w.ShowDialog();
            if (w.DialogResult == true)
            {
                products.Add(p);
                db.SaveChanges(); }
        }

        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as StackPanel).DataContext is Product p)
            {
                AddProductWindow w = new AddProductWindow();
                w.DataContext = p;
                w.ShowDialog();

                db.SaveChanges();
            }
        }

        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow();
            w.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                ProductsList.ItemsSource = products;
            }

            var list = products.Where(
                p => p.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                p.Description.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                p.Manufacturer.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)
                ).ToList();
             
            ProductsList.ItemsSource = list;
           
        }
    }
}