﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Models.ViewModels
{
    public class MovieDetailsViewmodel
    {
        public int Id { get; set; }
        
        public string Movie_Name { get; set; }
        public string Movie_Details { get; set; }
        public float Prices { get; set; }
        public string Hall { get; set; }
        public string MoviePicture { get; set; }
        public int Seat { get; set; }
        public DateTime DateAndTimeS { get; set; }
        public DateTime DateAndTimeE { get; set; }

        //adding the category
        public string category { get; set; }
    
        public string Age { get; set; }
       
        public string Rating { get; set; }
    }
}
