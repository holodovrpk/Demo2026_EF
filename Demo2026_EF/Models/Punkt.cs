using System; // Базовое пространство имён .NET
using System.Collections.Generic; // Для работы с коллекциями (ICollection)
using System.ComponentModel.DataAnnotations; // Атрибуты валидации данных (MaxLength)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    // Класс Punkt представляет пункт (например, пункт выдачи или обслуживания)
    // Используется как сущность базы данных в Entity Framework
    public class Punkt
    {
        // Первичный ключ таблицы Punkt
        public int PunktId { get; set; }

        // Адрес пункта
        // Максимальная длина строки — 200 символов
        // Может быть null, если адрес не задан
        [MaxLength(200)]
        public string? Adres { get; set; }

        // Навигационное свойство
        // Коллекция заказов, связанных с данным пунктом
        // Может быть null, если заказы отсутствуют
        public ICollection<Order>? Orders { get; set; }
    }
}
