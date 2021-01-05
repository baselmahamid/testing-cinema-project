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
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateofMovie { get; set; }
        public string MoviePicture { get; set; }
       
        //adding the price
        public string Price { get; set; }
        
        //adding the category
        public string category { get; set; }
        public string hall { get; set; }
        public string Age { get; set; }
        public string Seat { get; set; }
        public string Rating { get; set; }
    }
}
