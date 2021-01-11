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
        public string Movie_Name { get; set; }
        public string Hall { get; set; }
        public String seatno { get; set; }
        public string UserId { get; set; }
        public DateTime DateAndTimeS { get; set; }
        public DateTime DateAndTimeE { get; set; }
        public int Seat { get; set; }
        public int CartId { get; set; }
        public int ShowId { get; set; }
       


    }
}
