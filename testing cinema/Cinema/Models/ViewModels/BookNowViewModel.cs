using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.ViewModels
{
    public class BookNowViewModel
    {
        [Key]
        public string Movie_Name { get; set; }
        public DateTime Movie_Date { get; set; }
        public string SeatNo { get; set; }
        public int Amount { get; set; }
        public int MovieId { get; set; }
        

    }
}
