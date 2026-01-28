using Demo2026_EF.Models;              // Подключаем модели (User, Product, Order, Punkt) и DbContext
using Microsoft.EntityFrameworkCore;   // Нужен для методов EF Core (Load, Local и т.д.)
using System.Text;
using System.Windows;                 // Базовые классы WPF (Window, Visibility и т.п.)
using System.Windows.Controls;         // Элементы управления (TextBox, ListBox, и т.д.)
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;            // События мыши/клавиатуры (MouseButtonEventArgs)
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;  // ObservableCollection для привязки данных в WPF

namespace Demo2026_EF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Контекст базы данных EF Core (подключение и работа с таблицами)
        Demo2026_EFContext db = new Demo2026_EFContext();

        // Коллекция товаров, удобная для привязки к UI (обновления в списке происходят автоматически)
        ObservableCollection<Product>? products = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов окна из XAML

            // Загружаем товары из БД в локальный кэш EF
            db.Products.Load();

            // Берём локальные данные EF как ObservableCollection для привязки к ListView/ListBox
            products = db.Products.Local.ToObservableCollection();

            // Привязываем список товаров к элементу интерфейса
            ProductsList.ItemsSource = products;

            // Формируем список категорий вручную
            List<string> cat = new List<string>();
            cat.Add("Все категории");
            cat.Add("Женская обувь");
            cat.Add("Мужская обувь");

            // Привязываем категории к ComboBox/ListBox категорий
            ListCategory.ItemsSource = cat;
            ListCategory.SelectedIndex = 0; // По умолчанию показываем "Все категории"

            // Отображаем информацию о пользователе (имя и роль)
            txtUser.Text = LoginUser.name + "\n" + LoginUser.role;

            // Если зашёл клиент — скрываем панель/элементы для не-клиента и уменьшаем окно
            if (LoginUser.role == "Авторизированный клиент")
            {
                NoClient.Visibility = Visibility.Collapsed; // скрываем блок, недоступный клиенту
                this.Height = 500;                          // меняем высоту окна
            }

            // Если зашёл менеджер — скрываем блок, недоступный менеджеру
            if (LoginUser.role == "Менеджер")
            {
                NoManager.Visibility = Visibility.Collapsed;
            }
        }

        // Кнопка "Добавить товар"
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новый объект товара
            Product p = new Product();

            // Открываем окно добавления/редактирования товара
            AddProductWindow w = new AddProductWindow();

            // Передаём товар в DataContext, чтобы окно работало с ним через привязку
            w.DataContext = p;

            // Показываем окно как модальное (пока оно открыто — главное окно недоступно)
            w.ShowDialog();

            // Если пользователь нажал "Сохранить" и окно вернуло DialogResult=true
            if (w.DialogResult == true)
            {
                // Добавляем новый товар в коллекцию (UI обновится автоматически)
                products.Add(p);

                // Сохраняем изменения в базу
                db.SaveChanges();
            }
        }

        // Обработка клика мыши по элементу "Редактировать" (например, иконка/панель в шаблоне)
        private void Edit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Ограничение прав: клиент и менеджер не могут редактировать товары
            if (LoginUser.role == "Авторизированный клиент" ||
                LoginUser.role == "Менеджер")
                return;

            // Пытаемся получить товар из DataContext элемента, по которому кликнули
            if ((sender as StackPanel).DataContext is Product p)
            {
                // Открываем окно редактирования
                AddProductWindow w = new AddProductWindow();
                w.DataContext = p;
                w.ShowDialog();

                // После закрытия окна сохраняем изменения в БД
                db.SaveChanges();
            }
        }

        // Кнопка "Заказы" — открывает окно заказов
        private void Orders_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow w = new OrderWindow();
            w.ShowDialog();
        }

        // Поиск по товарам при изменении текста в поле поиска
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Если строка поиска пустая — показываем весь список
            if (txtSearch.Text == "")
            {
                ProductsList.ItemsSource = products;
            }

            // Фильтруем товары по имени/описанию/производителю без учёта регистра
            var list = products.Where(
                p => p.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                     p.Description.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                     p.Manufacturer.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase)
                ).ToList();

            // Отображаем отфильтрованный список
            ProductsList.ItemsSource = list;
        }

        // Сортировка по возрастанию (по количеству на складе)
        private void Asc_Click(object sender, RoutedEventArgs e)
        {
            // Пересоздаём ObservableCollection в отсортированном порядке
            products = new ObservableCollection<Product>(
                products.OrderBy(p => p.Count)
            );

            // Обновляем источник данных списка
            ProductsList.ItemsSource = products;
        }

        // Сортировка по убыванию (по количеству на складе)
        private void Desc_Click(object sender, RoutedEventArgs e)
        {
            products = new ObservableCollection<Product>(
                products.OrderByDescending(p => p.Count)
            );

            ProductsList.ItemsSource = products;
        }

        // Фильтрация по категории при смене выбранного значения
        private void ListCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Если выбрано "Все категории" — показываем весь список
            if (ListCategory.SelectedItem.ToString() == "Все категории")
            {
                ProductsList.ItemsSource = products;
                return;
            }

            // Фильтруем товары по выбранной категории
            var list = products.Where(p =>
                p.Category == ListCategory.SelectedItem.ToString()).ToList();

            // Отображаем результат фильтрации
            ProductsList.ItemsSource = list;
        }
    }
}
