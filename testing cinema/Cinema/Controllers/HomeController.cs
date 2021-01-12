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
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _context;


        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {

            _context = context;
            _userManager = userManager;
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
            vm.UserId = _userManager.GetUserId(HttpContext.User);


            return View(vm);
           
        }

        [HttpPost]
        public IActionResult BookNow(BookNowViewModel vm )
        {
            var vs = _context.ShowTimes.Where(a => a.ShowId == vm.Id).FirstOrDefault();
            List<BookingTable> booking = new List<BookingTable>();
            List<Cart> carts = new List<Cart>();
            string seatno = vm.seatno.ToString();
            int showId = vs.ShowId;
            string[] seatnoarray = seatno.Split(',');
            count = seatnoarray.Length;
            
            if (checkseat(seatno,showId)==false)
            {
                foreach(var item in seatnoarray)
                {
                    carts.Add(new Cart { ShowId = showId,UserId=_userManager.GetUserId(HttpContext.User),DateAndTimeE = vs.DateAndTimeE, DateAndTimeS = vs.DateAndTimeS, seatno = item });
                   
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


        [HttpGet]
        public IActionResult YourOrders(string Id)
        {
            
            var orders = _context.Cart.Where(a => a.UserId == Id).ToList();
            

            return View(orders);
        }

        
        public IActionResult Editcart(int id)
        {
            
                var cartt = _context.Cart.Where(s => s.Id == id).FirstOrDefault();
         //  var sh = _context.ShowTimes.Where(s=>s.)

                return View(cartt);

        }

        [HttpPost]
        public IActionResult Editcart( BookNowViewModel vmodel, Cart cartt)
        {
            
            cartt.UserId = vmodel.UserId;
            cartt.seatno = vmodel.seatno;
            cartt.ShowId = vmodel.ShowId;
            ViewBag.mov =vmodel.Movie_Name ;
            _context.Cart.Update(cartt);
            _context.SaveChanges();
            return RedirectToAction("Editcart", "Home");

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
