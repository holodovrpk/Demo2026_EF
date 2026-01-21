using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    public class Punkt
    {
        public int PunktId { get; set; }
        [MaxLength(200)]
        public string? Adres { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
