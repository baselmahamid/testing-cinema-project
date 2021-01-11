using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public String seatno { get; set; }
        public string UserId { get; set; }
        public DateTime DateAndTimeS { get; set; }
        public DateTime DateAndTimeE { get; set; }
        
        public int ShowId { get; set; }
    }
}
