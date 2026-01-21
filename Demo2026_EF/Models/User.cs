using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    public class User
    {
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Role { get; set; }
        [MaxLength(70)]
        public string FIO { get; set; }
        [MaxLength(30)]
        public string Login { get; set; }
        [MaxLength(30)]
        public string Pass { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
