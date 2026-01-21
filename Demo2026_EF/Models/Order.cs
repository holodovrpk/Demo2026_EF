using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int? Count {  get; set; }
        public DateTime? DateOrder { get; set; }
        public DateTime? Delivery {  get; set; }

        public int? PunktId { get; set; }
        public Punkt? Punkt { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }//

        public int? CodeReciever { get; set; }
        public string? Status { get; set; }
    }
}
