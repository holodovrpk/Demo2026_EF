using System;                          // Базовые типы .NET
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;                  // Базовые классы WPF (Window, DialogResult)
using System.Windows.Controls;          // Элементы управления
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo2026_EF
{
    /// <summary>
    /// Логика взаимодействия для AddProductWindow.xaml
    /// Окно добавления и редактирования товара
    /// </summary>
    public partial class AddProductWindow : Window
    {
        // Конструктор окна
        public AddProductWindow()
        {
            InitializeComponent(); // Инициализация элементов интерфейса из XAML
        }

        // Обработчик нажатия кнопки "Сохранить"
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Устанавливаем результат диалогового окна в true
            // Это сигнал для вызывающего окна, что данные нужно сохранить
            DialogResult = true;

            // После установки DialogResult окно автоматически закрывается
        }
    }
}
