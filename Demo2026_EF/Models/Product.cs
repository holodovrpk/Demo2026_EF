using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [MaxLength(15)]
        public string Artikul { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(10)]
        public string? Unit { get; set; }
        public decimal Price { get; set; }
        [MaxLength(100)]
        public string? Supplier { get; set; }
        [MaxLength(100)]
        public string? Manufacturer { get; set; }
        [MaxLength(100)]
        public string? Category { get; set; }
        public double Discount { get; set; }
        public int Count { get; set; }
        [MaxLength(200)]
        public string? Description { get; set; }
        [MaxLength(20)]
        public string? Photo { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
