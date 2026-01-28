using System; // Базовое пространство имён .NET
using System.Collections.Generic; // Для работы с коллекциями (ICollection)
using System.ComponentModel.DataAnnotations; // Атрибуты валидации данных (MaxLength)
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    // Класс Product представляет товар
    // Используется как сущность базы данных в Entity Framework
    public class Product
    {
        // Первичный ключ таблицы Product
        public int ProductId { get; set; }

        // Артикул товара
        // Максимальная длина — 15 символов
        [MaxLength(15)]
        public string Artikul { get; set; }

        // Наименование товара
        // Максимальная длина — 100 символов
        [MaxLength(100)]
        public string Name { get; set; }

        // Единица измерения (шт., кг, л и т.п.)
        // Может быть null
        [MaxLength(10)]
        public string? Unit { get; set; }

        // Цена товара
        public decimal Price { get; set; }

        // Поставщик товара
        // Максимальная длина — 100 символов
        // Может быть null
        [MaxLength(100)]
        public string? Supplier { get; set; }

        // Производитель товара
        // Максимальная длина — 100 символов
        // Может быть null
        [MaxLength(100)]
        public string? Manufacturer { get; set; }

        // Категория товара
        // Максимальная длина — 100 символов
        // Может быть null
        [MaxLength(100)]
        public string? Category { get; set; }

        // Размер скидки (например, 0.1 = 10%)
        public double Discount { get; set; }

        // Количество товара на складе
        public int Count { get; set; }

        // Описание товара
        // Максимальная длина — 200 символов
        // Может быть null
        [MaxLength(200)]
        public string? Description { get; set; }

        // Путь к изображению товара или имя файла
        // Максимальная длина — 20 символов
        // Может быть null
        [MaxLength(20)]
        public string? Photo { get; set; }

        // Навигационное свойство
        // Коллекция заказов, в которых участвует данный товар
        public ICollection<Order>? Orders { get; set; }
    }
}
