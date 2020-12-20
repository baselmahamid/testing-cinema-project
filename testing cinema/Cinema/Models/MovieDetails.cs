using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    public class MovieDetails
    {
        public int Id { get; set; }
        public string Movie_Name { get; set; }
        public string Movie_Details { get; set; }
        public  DateTime DateAndTime { get; set; }
        public  string MoivePicture { get; set; }

        public virtual ICollection<BookingTable> booking { get; set; }

        //adding the price table
        public string Price { get; set; }

        //adding the category
        public string category { get; set; }


    }
}
