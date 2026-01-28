using System; // Базовое пространство имён .NET
using System.Collections.Generic; // Для использования коллекций (ICollection)
using System.ComponentModel.DataAnnotations; // Для атрибутов валидации (MaxLength)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    // Класс User представляет пользователя системы
    // Используется как модель данных (Entity) в Entity Framework
    public class User
    {
        // Первичный ключ таблицы User
        public int UserId { get; set; }

        // Роль пользователя (например: Администратор, Менеджер, Клиент)
        // Максимальная длина строки — 50 символов
        [MaxLength(50)]
        public string Role { get; set; }

        // ФИО пользователя
        // Максимальная длина строки — 70 символов
        [MaxLength(70)]
        public string FIO { get; set; }

        // Логин пользователя для входа в систему
        // Максимальная длина строки — 30 символов
        [MaxLength(30)]
        public string Login { get; set; }

        // Пароль пользователя
        // Максимальная длина строки — 30 символов
        // (на практике рекомендуется хранить хэш пароля)
        [MaxLength(30)]
        public string Pass { get; set; }

        // Навигационное свойство
        // Коллекция заказов, связанных с данным пользователем
        // Может быть null, если у пользователя нет заказов
        public ICollection<Order>? Orders { get; set; }
    }
}
