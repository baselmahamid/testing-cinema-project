using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.ViewModels
{
    public class MovieDetailsViewmodel
    {
        public int Id { get; set; }

        [Required]
        public string Movie_Name { get; set; }
        [Required]
        public string Movie_Details { get; set; }
        
        public int Cost { get; set; }
        [Required]
        public string Hall { get; set; }
        [Required]
        public string MoviePicture { get; set; }
        [Required]
        public int Seat { get; set; }
        [Display(Name = "Start show")]
        [Required]
        public DateTime DateAndTimeS { get; set; }
        [Display(Name = "End show")]
        [Required]
        public DateTime DateAndTimeE { get; set; }

        [Required]
        //adding the category
        public string category { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public string Rating { get; set; }
    }
}
