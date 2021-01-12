using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [Display(Name = "Seat Number")]
        public String seatno { get; set; }
        public string UserId { get; set; }

        [Display(Name = "Start show")]
        public DateTime DateAndTimeS { get; set; }
        [Display(Name = "End show")]
        public DateTime DateAndTimeE { get; set; }
        public int Cost { get; set; }
        public int ShowId { get; set; }
    }
}
