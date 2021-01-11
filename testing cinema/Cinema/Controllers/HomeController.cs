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
using System.Globalization;

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
            var item = _context.ShowTimes.Where(a => a.ShowId == Id).FirstOrDefault();
            vm.DateAndTimeS = item.DateAndTimeS;
            vm.DateAndTimeE = item.DateAndTimeE;
            vm.ShowId = item.ShowId;
            vm.Movie_Name = item.Movie_Name;
            vm.Hall = item.Hall;
            vm.Seat = item.Seat;
           
            
            return View(vm);
           
        }

        [HttpPost]
        public IActionResult BookNow(BookNowViewModel vm )
        {
            
            List<BookingTable> booking = new List<BookingTable>();
            List<Cart> carts = new List<Cart>();
            string seatno = vm.seatno.ToString();
            int showId = vm.ShowId;
            string[] seatnoarray = seatno.Split(',');
            count = seatnoarray.Length;
            
            if (checkseat(seatno,showId)==false)
            {
                foreach(var item in seatnoarray)
                {
                    carts.Add(new Cart { ShowId = vm.ShowId,DateAndTimeE = vm.DateAndTimeE, DateAndTimeS = vm.DateAndTimeS, seatno = item });
                
                }
                foreach(var item in carts)
                {
                    _context.Cart.Add(item);
                    _context.SaveChanges();

                }
               
                TempData["sucess"] = "seat no booked , check to cart";
            }
            else
            {
                
                TempData["sucess"] = "Pleas change Your seat number";
            }
            return RedirectToAction("BookNow");
        }


            private bool checkseat(string seatno, int ShowId)
        {
            string seats = seatno;
            string[] seatreserve = seats.Split(',');
            var seatnolist = _context.Cart.Where(a => a.ShowId == ShowId).ToList();
            foreach(var item in seatnolist)
            {
                string alreadybook = item.seatno;
                foreach(var item1 in seatreserve)
                {
                    if(item1==alreadybook)
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



        public IActionResult YourOrders(int Id)
        {
            return View();
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
            var model = _context.ShowTimes.Where(p => p.Id == id );
            ViewBag.id = id;
            

            return View(model);
        
        }


    }
}
