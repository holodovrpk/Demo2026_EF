using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF
{
    // Статический класс LoginUser
    // Используется для хранения данных текущего авторизованного пользователя
    static public class LoginUser
    {
        // Имя (или ФИО) текущего пользователя
        // Доступно из любого места приложения
        static public string name { get; set; }

        // Роль текущего пользователя (например: Администратор, Пользователь)
        // Используется для разграничения прав доступа
        static public string role { get; set; }
    }
}
