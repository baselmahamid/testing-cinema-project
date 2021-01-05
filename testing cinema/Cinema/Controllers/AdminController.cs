using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Data;
using Cinema.Models;
using Cinema.Models.ViewModels;
using FileUploadControl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;
        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            _upload = upload;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, MovieDetailsViewmodel vmodel, MovieDetails movie)
        {
            movie.Movie_Name = vmodel.Name;
            movie.Movie_Details = vmodel.Description;
            movie.DateAndTime = vmodel.DateofMovie;
            movie.Price = vmodel.Price;
            movie.category = vmodel.category;
            movie.hall = vmodel.hall;
            movie.Age = vmodel.Age;
            movie.Seat = vmodel.Seat;
            movie.Rating = vmodel.Rating;
            foreach (var item in files)
            {
                movie.MoivePicture = "~/uploads/" + item.FileName.Trim();

            }
            _upload.Uploadfilemultiple(files);
            _context.MovieDetails.Add(movie);
            _context.SaveChanges();
            TempData["Sucess"] = "Save Your Movie";
            return RedirectToAction("Create", "Admin");

        }

        [HttpGet]
        public IActionResult CheckBookSeat()
        {
            var getBookingTable = _context.BookingTable.ToList().OrderByDescending(a => a.DateToPresent);
            return View(getBookingTable);
        } 

        //adding the admin action for admin page

            [HttpGet]
        public IActionResult admin()
        {
            var getMovieList = _context.MovieDetails.ToList();

            return View(getMovieList);
        }
        

    }
}