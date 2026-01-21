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
using System.Windows.Shapes;
using Demo2026_EF.Models;

namespace Demo2026_EF
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Demo2026_EFContext db = new Demo2026_EFContext();

            User user = db.Users.FirstOrDefault(u => 
                        u.Login == txtLogin.Text
                        && u.Pass == txtPass.Text);

            if (user == null)
            {
                MessageBox.Show("Ошибка в логине/пароле!");
                return;
            }

            MainWindow w = new MainWindow();
            w.Show();

            this.Close();



        }
    }
}
