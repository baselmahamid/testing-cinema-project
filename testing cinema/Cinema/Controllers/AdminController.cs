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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private UploadInterface _upload;
        private UserManager<IdentityUser> _userManager;



        public AdminController(ApplicationDbContext context, UploadInterface upload, UserManager<IdentityUser> userManager)
        {
            
            _upload = upload;
            if(_context == null)
                _context = context;
            _userManager = userManager;
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
            if (_userManager.GetUserId(HttpContext.User) != "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();

            }
        }
        [HttpPost]
        public IActionResult Create(IList<IFormFile> files, MovieDetailsViewmodel vmodel, MovieDetails movie)
        {
            movie.Movie_Name = vmodel.Movie_Name;
            movie.Movie_Details = vmodel.Movie_Details;
            movie.category = vmodel.category;   
            movie.Age = vmodel.Age;
     //       movie.Prices = vmodel.Prices;
            movie.Rating = vmodel.Rating;
            foreach (var item in files)
            {
                movie.MoivePicture = "~/uploads/" + item.FileName.Trim();

            }
            _upload.Uploadfilemultiple(files);
            _context.MovieDetails.Add(movie);
            _context.SaveChanges();
            TempData["Sucess"] = "Movie added to the list";
            if (_userManager.GetUserId(HttpContext.User) != "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Create", "Admin");
            }
        }

        [HttpGet]
        public IActionResult AddShow()
        {
            if (_userManager.GetUserId(HttpContext.User) != "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

       [HttpPost]
        public IActionResult AddShow(MovieDetailsViewmodel vmodel,ShowTime moviee, MovieDetails movie)
        {
            moviee.DateAndTimeS = vmodel.DateAndTimeS;
            moviee.DateAndTimeE = vmodel.DateAndTimeE;
            moviee.Cost = vmodel.Cost;
            moviee.Hall = vmodel.Hall;
            moviee.Seat = vmodel.Seat;
          //  moviee.Prices = vmodel.Prices;
            foreach (var item in _context.MovieDetails.Where(m => m.Id==movie.Id))
            {
                moviee.Movie_Name = item.Movie_Name;
                moviee.Movie_Details = item.Movie_Details;
                moviee.MoivePicture = item.MoivePicture;
                moviee.Rating = item.Rating;
                moviee.category = item.category;
                moviee.Age = item.Age;
                

            }
           
            
            _context.ShowTimes.Add(moviee);
            _context.SaveChanges();
            TempData["Sucess"] = "Show Time added to list";
            if (_userManager.GetUserId(HttpContext.User) != "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("admin", "Admin");
            }
        }




        //adding the admin action for admin page

        [HttpGet]
        public IActionResult admin()
        {
            var getMovieList = _context.MovieDetails.ToList();

            foreach (var item in getMovieList)
            {
                item.Cshow = _context.ShowTimes.Where(a => a.Id == item.Id ).Count();
                _context.MovieDetails.Update(item);
            }

            if (_userManager.GetUserId(HttpContext.User) != "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View(getMovieList);
            }
        }

        public IActionResult Edit(int id)
        {

            var movie = _context.MovieDetails.Where(s => s.Id == id).FirstOrDefault();
            if (_userManager.GetUserId(HttpContext.User) != "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return View(movie);
            }
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
            
            _upload.Uploadfilemultiple(files);
            ViewBag.pic = movie.MoivePicture;
            _context.MovieDetails.Update(movie);

            _context.SaveChanges();
            TempData["Sucess"] = "Save Your Movie";
            if (_userManager.GetUserId(HttpContext.User) != "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return RedirectToAction("Edit", "Admin");
            }
        }

        public IActionResult Delete(int id)
        {

            var movie = _context.MovieDetails.Where(s => s.Id == id).FirstOrDefault();
            ViewBag.pic = movie.MoivePicture;
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