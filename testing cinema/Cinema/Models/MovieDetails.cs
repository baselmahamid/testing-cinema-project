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
        [Display(Name = "Movie")]
        
        public string Movie_Name { get; set; }

        [Display(Name = "Details")]
        public string Movie_Details { get; set; }

       

        [Display(Name = "Movie Poster")]
        public  string MoivePicture { get; set; }

        [Display(Name = "Shows Number")]
        public int Cshow { get; set; }


        //adding the category
        [Display(Name = "Category")]
        public string category { get; set; }
        
       
        public string Age { get; set; }
       
        public string Rating { get; set; }

        internal static object where(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        internal static object Where(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        internal static IEnumerable<object> where(int id)
        {
            throw new NotImplementedException();
        }
    }
}
