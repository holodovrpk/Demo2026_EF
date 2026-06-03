using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
