using System; // Базовое пространство имён .NET
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    // Класс Order представляет заказ
    // Используется как сущность базы данных в Entity Framework
    public class Order
    {
        // Первичный ключ таблицы Order
        public int OrderId { get; set; }

        // Внешний ключ на товар
        // Может быть null, если товар не привязан
        public int? ProductId { get; set; }

        // Навигационное свойство — товар, связанный с заказом
        public Product? Product { get; set; }

        // Количество товара в заказе
        // Может быть null
        public int? Count { get; set; }

        // Дата оформления заказа
        public DateTime? DateOrder { get; set; }

        // Дата доставки заказа
        public DateTime? Delivery { get; set; }

        // Внешний ключ на пункт выдачи
        // Может быть null
        public int? PunktId { get; set; }

        // Навигационное свойство — пункт выдачи заказа
        public Punkt? Punkt { get; set; }

        // Внешний ключ на пользователя
        // Может быть null
        public int? UserId { get; set; }

        // Навигационное свойство — пользователь, оформивший заказ
        public User? User { get; set; }

        // Код получения заказа (например, для выдачи в пункте)
        // Может быть null
        public int? CodeReciever { get; set; }

        // Статус заказа (например: "Новый", "В обработке", "Готов к выдаче")
        // Может быть null
        public string? Status { get; set; }
    }
}
