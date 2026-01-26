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

        }
    }
}
