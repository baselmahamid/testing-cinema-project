using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cinema.Models;
using Cinema.Data;
using Cinema.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cinema.Data.Migrations;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        int count = 1;
        bool flag = true;
        private UserManager<ApplicationId> _userManager;
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            
            _context = context;
          //  _userManager = userManager;
        }


        [HttpGet]
        public IActionResult BookNow(int Id)
        {
            BookNowViewModel vm = new BookNowViewModel();
            var item = _context.MovieDetails.Where(a => a.Id == Id).FirstOrDefault();
            vm.Movie_Name = item.Movie_Name;
            vm.Movie_Date = item.DateAndTime;
            vm.MovieId = Id;

            return View(vm);
        }




        [HttpPost]
        public IActionResult BookNow(BookNowViewModel vm)
        {
            List<BookingTable> booking = new List<BookingTable>();
            List<Cart> carts = new List<Cart>();
            string seatno = vm.SeatNo.ToString();
            int movieId = vm.MovieId;
            string[] seatnoArray = seatno.Split(',');
            count = seatnoArray.Length;

            if (checkseat(seatno, movieId) == false)
            {
                foreach(var item in seatnoArray)
                {
                    carts.Add(new Cart
                    { Amount = 150, MoiveId = vm.MovieId, UserId = _userManager.GetUserId(HttpContext.User), date = vm.Movie_Date, seatno = item } );
                }
                foreach (var item in carts)
                {
                    _context.Cart.Add(item);
                    _context.SaveChanges();

                }

                TempData["Sucess"] = "Seat no Booked, Check Your Cart";


            }
            else
            {

                TempData["seatnomsg"] = "Please Change Your Seat number";
            }

            return RedirectToAction("BookNow");
        }

        
        private bool checkseat(string seatno, int movieId)
        {
            //  throw new NotImplementedException();
            string seats = seatno;
            string[] seatreserve = seats.Split(',');
            var seatnolist = _context.BookingTable.Where(a => a.MovieDetailsId == movieId).ToList();
            foreach(var item in seatnolist)
            {
                string alreadybook = item.seatno;

                foreach (var item1 in seatreserve)
                {
                    if (item1==alreadybook)
                    {
                        flag = false;
                        break;
                    }

                }

            }

            if (flag == false)
                return true;
            else
                return false;


        }
     

        public IActionResult Index()
        {
            
            var getMovieList = _context.MovieDetails.ToList();

            return View(getMovieList);
        }

        


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //adding details page

        [HttpGet]
        public IActionResult Details(int id)
        { 
            var model = _context.MovieDetails.Where(p => p.Id == id).FirstOrDefault();
            return View(model);
        
        }


    }
}
