using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models
{
    [Table("ShowTime")]
    public class ShowTime
    {
       
      
        public int Id { get; set; }
        [Display(Name = "Movie")]

       
        public string Movie_Name { get; set; }

        [Key]
        public int ShowId { get; set; }
        public string Movie_Details { get; set; }


        [Display(Name = "Movie Poster")]
       
        public string MoivePicture { get; set; }
       
        public int Cost { get; set; }
        public string Hall { get; set; }
        
        public int Seat { get; set; }
        [Display(Name = "Start show")]
        public DateTime DateAndTimeS { get; set; }
        [Display(Name = "End show")]
        public DateTime DateAndTimeE { get; set; }

      


        //adding the category

        public string category { get; set; }

      
        public string Age { get; set; }
     
        public string Rating { get; set; }

    }
}
