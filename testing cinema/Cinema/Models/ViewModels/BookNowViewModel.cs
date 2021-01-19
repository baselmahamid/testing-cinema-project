using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.ViewModels
{
    public class BookNowViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Movie")]
        public string Movie_Name { get; set; }
        public string Hall { get; set; }
        public int Cost { get; set; }
        [Display(Name = "Seat Number")]
        public String seatno { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Start show")]
        public DateTime DateAndTimeS { get; set; }
        [Display(Name = "End show")]
        public DateTime DateAndTimeE { get; set; }
        public int Seat { get; set; }
        public int CartId { get; set; }
        [Display(Name = "Show ID")]
        public int ShowId { get; set; }
       


    }
}
