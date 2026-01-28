using System;                          // Базовые типы .NET
using System.Collections.Generic;
using System.Linq;                     // Для LINQ-запросов (FirstOrDefault)
using System.Text;
using System.Threading.Tasks;
using System.Windows;                  // Базовые классы WPF (Window, MessageBox и т.п.)
using System.Windows.Controls;          // Элементы управления (TextBox, Button)
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Demo2026_EF.Models;              // Подключаем модели и контекст EF (User, Demo2026_EFContext)

namespace Demo2026_EF
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// Окно авторизации пользователя
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent(); // Инициализация элементов интерфейса из XAML
        }

        // Обработчик нажатия кнопки "Войти"
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Создаём контекст базы данных для обращения к таблице Users
            Demo2026_EFContext db = new Demo2026_EFContext();

            // Ищем пользователя в базе по введённому логину и паролю
            // FirstOrDefault вернёт пользователя, если найден, иначе null
            User user = db.Users.FirstOrDefault(u =>
                        u.Login == txtLogin.Text
                        && u.Pass == txtPass.Text);

            // Если пользователь не найден — выводим сообщение об ошибке и выходим из метода
            if (user == null)
            {
                MessageBox.Show("Ошибка в логине/пароле!");
                return;
            }

            // Сохраняем данные вошедшего пользователя в статический класс
            // чтобы они были доступны в других окнах приложения
            LoginUser.name = user.FIO;
            LoginUser.role = user.Role;

            // Создаём и открываем главное окно приложения
            MainWindow w = new MainWindow();

            // Можно было бы напрямую записать текст в элемент главного окна,
            // но правильнее хранить данные в LoginUser (как сделано выше)
            // w.txtUser.Text = user.FIO;

            w.Show();      // Показываем главное окно
            this.Close();  // Закрываем окно авторизации
        }
    }
}
