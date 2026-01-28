using System;                          // Базовые типы .NET
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;                  // Базовые классы WPF (Window, DialogResult)
using System.Windows.Controls;          // Элементы управления WPF
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo2026_EF
{
    /// <summary>
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// Окно добавления и редактирования заказа
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        // Конструктор окна
        public AddOrderWindow()
        {
            InitializeComponent(); // Инициализация компонентов интерфейса из XAML
        }

        // Обработчик нажатия кнопки "Сохранить"
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Устанавливаем результат диалогового окна в true
            // Это означает, что пользователь подтвердил сохранение данных
            DialogResult = true;

            // После установки DialogResult окно автоматически закрывается
        }
    }
}
