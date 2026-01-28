using Demo2026_EF.Models;                // Модели и DbContext (Order, User, Punkt, Product)
using Microsoft.EntityFrameworkCore;     // EF Core: Include(), Load(), Local и т.д.
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;    // ObservableCollection для обновления UI при изменениях
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;                    // WPF: Window, Visibility, MessageBox и т.д.
using System.Windows.Controls;            // WPF-контролы
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;               // События мыши (MouseButtonEventArgs)
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo2026_EF
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// Окно просмотра/добавления/редактирования заказов
    /// </summary>
    public partial class OrderWindow : Window
    {
        // Контекст базы данных
        Demo2026_EFContext db = new Demo2026_EFContext();

        // Коллекция заказов для привязки к списку (обновляет UI автоматически)
        ObservableCollection<Order> orders = new ObservableCollection<Order>();

        public OrderWindow()
        {
            InitializeComponent(); // Инициализация элементов из XAML

            // Загружаем заказы из БД и сразу подтягиваем связанные данные (пункт выдачи)
            // Include нужен, чтобы o.Punkt был загружен вместе с заказом
            db.Orders.Include(o => o.Punkt).Load();

            // Берём локальные данные EF (кэш) и превращаем в ObservableCollection
            orders = db.Orders.Local.ToObservableCollection();

            // Привязываем список заказов к элементу интерфейса
            OrdersList.ItemsSource = orders;

            // Настройка интерфейса по роли:
            // если менеджер — скрываем элементы, которые менеджеру недоступны
            if (LoginUser.role == "Менеджер")
            {
                NoManager.Visibility = Visibility.Collapsed;
            }
        }

        // Кнопка "Добавить заказ"
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новый заказ
            Order o = new Order();

            // Открываем окно добавления/редактирования заказа
            AddOrderWindow w = new AddOrderWindow();

            // Заполняем списки (ComboBox/ListBox) данными из БД:
            // пользователи, пункты выдачи, товары
            w.ListUser.ItemsSource = db.Users.ToList();
            w.ListPunkt.ItemsSource = db.Punkt.ToList();
            w.ListProduct.ItemsSource = db.Products.ToList();

            // Передаём объект заказа в DataContext (для привязки полей в XAML)
            w.DataContext = o;

            // Показываем окно как диалог и проверяем результат
            if (w.ShowDialog() == true)
            {
                // Добавляем заказ в коллекцию (UI обновится)
                orders.Add(o);

                // Сохраняем изменения в базу данных
                db.SaveChanges();
            }
        }

        // Обработка клика по заказу в списке (например, для редактирования)
        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Ограничение прав: менеджер не может редактировать заказы (по вашей логике)
            if (LoginUser.role == "Менеджер")
                return;

            // Получаем заказ из DataContext элемента, по которому кликнули
            if ((sender as StackPanel).DataContext is Order o)
            {
                // Окно редактирования заказа
                AddOrderWindow w = new AddOrderWindow();

                // Подгружаем справочные данные для выбора пользователя/пункта/товара
                w.ListUser.ItemsSource = db.Users.ToList();
                w.ListPunkt.ItemsSource = db.Punkt.ToList();
                w.ListProduct.ItemsSource = db.Products.ToList();

                // Передаём выбранный заказ в окно
                w.DataContext = o;

                // Открываем окно редактирования
                w.ShowDialog();

                // Сохраняем изменения после закрытия окна
                db.SaveChanges();
            }
        }
    }
}
