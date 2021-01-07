using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Cinema.Data;
using Cinema.Models;
using Cinema.Models.ViewModels;
using FileUploadControl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;
        


        public AdminController(ApplicationDbContext context, UploadInterface upload)
        {
            
            _upload = upload;
            if(_context == null)
                _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _context.SaveChanges();
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
            movie.Movie_Name = vmodel.Movie_Name;
            movie.Movie_Details = vmodel.Movie_Details;
            movie.category = vmodel.category;   
            movie.Age = vmodel.Age;  
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
        public IActionResult AddShow()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddShow(MovieDetailsViewmodel vmodel,ShowTime moviee, MovieDetails movie)
        {
            moviee.DateAndTimeS = vmodel.DateAndTimeS;
            moviee.DateAndTimeE = vmodel.DateAndTimeE;
            moviee.Price = vmodel.Price;
            moviee.Hall = vmodel.Hall;
            moviee.Seat = vmodel.Seat;
            foreach (var item in _context.MovieDetails.Where(m => m.Id==movie.Id))
            {
                moviee.Movie_Name = item.Movie_Name;
                moviee.Movie_Details = item.Movie_Details;
                moviee.MoivePicture = item.MoivePicture;
                moviee.Rating = item.Rating;

            }
            _context.ShowTimes.Add(moviee);
            _context.SaveChanges();
            TempData["Sucess"] = "Save Your Movie";
            return RedirectToAction("admin", "Admin");

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

        public IActionResult Edit(int id)
        {

            var movie = _context.MovieDetails.Where(s => s.Id == id).FirstOrDefault();

            
            return View(movie);

        }
        [HttpPost]
        public IActionResult Edit(IList<IFormFile> files, MovieDetailsViewmodel vmodel, MovieDetails movie)
        {
            movie.Movie_Name = vmodel.Movie_Name;
            movie.Movie_Details = vmodel.Movie_Details;
            
          
            movie.category = vmodel.category;
          
            movie.Age = vmodel.Age;
          
            movie.Rating = vmodel.Rating;

            foreach (var item in files)
            {
                movie.MoivePicture = "~/uploads/" + item.FileName.Trim();

            }
            ViewBag.pic = vmodel.MoviePicture;
            _upload.Uploadfilemultiple(files);
            
            _context.MovieDetails.Update(movie);

            _context.SaveChanges();
            TempData["Sucess"] = "Save Your Movie";
            return RedirectToAction("Edit", "Admin");
        }

        public IActionResult Delete(int id)
        {

            var movie = _context.MovieDetails.Where(s => s.Id == id).FirstOrDefault();
            return View(movie);

        }
        [HttpPost]
        public IActionResult Delete(IList<IFormFile> files, MovieDetailsViewmodel vmodel, MovieDetails movie)
        {
            movie.Movie_Name = vmodel.Movie_Name;
            movie.Movie_Details = vmodel.Movie_Details;
            
           
            movie.category = vmodel.category;
           
            movie.Age = vmodel.Age;
           
            movie.Rating = vmodel.Rating;
            foreach (var item in files)
            {
                movie.MoivePicture = "~/uploads/" + item.FileName.Trim();

            }
            _upload.Uploadfilemultiple(files);
            _context.MovieDetails.Remove(movie);
            _context.SaveChanges();
            TempData["Sucess"] = "Save Your Movie";
            return RedirectToAction("admin", "Admin");

        }


    }
}