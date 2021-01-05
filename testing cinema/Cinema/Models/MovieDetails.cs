using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        [Key]
        [Display(Name = "Movie")]
        public string Movie_Name { get; set; }
        public string Movie_Details { get; set; }
       
        public  DateTime DateAndTime { get; set; }
        [Display(Name = "Movie Poster")]
        public  string MoivePicture { get; set; }

        public virtual ICollection<BookingTable> booking { get; set; }

        //adding the price table
        public string Price { get; set; }

        //adding the category
        public string category { get; set; }
        
        public string hall { get; set; }
        public string Age { get; set; }
        public string Seat { get; set; }
        public string Rating { get; set; }


    }
}
