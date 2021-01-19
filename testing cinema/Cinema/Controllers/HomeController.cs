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
           
            List<Cart> carts = new List<Cart>();
            string seatno = vm.seatno.ToString();
            int showId = vs.ShowId;
            string[] seatnoarray = seatno.Split(',');
            count = seatnoarray.Length;
            
            if (checkseat(seatno,showId)==false)
            {
                foreach(var item in seatnoarray)
                {
                    carts.Add(new Cart { Cost=vs.Cost,ShowId = showId,UserId=_userManager.GetUserId(HttpContext.User),DateAndTimeE = vs.DateAndTimeE, DateAndTimeS = vs.DateAndTimeS, seatno = item });
                   
                }
                foreach(var item in carts)
                {

                    
                    _context.Cart.Add(item);
                    _context.SaveChanges();

                }

                
                TempData["success"] = "Your Seat added to the cart";
            }
            else
            {
                
                TempData["success"] = "Please Select another seat, This number occupied";
            }
            ViewBag.id = showId;
            
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
            int total = 0;
            foreach (var item in orders)
            {
                total += item.Cost;
            }
            ViewBag.tocost = total;

            return View(orders);
        }

        
        public IActionResult DeleteCart(int id)
        {
            
                var cartt = _context.Cart.Where(s => s.Id == id).FirstOrDefault();
        

                return View(cartt);

        }

        [HttpPost]
        public IActionResult DeleteCart(BookNowViewModel vm,Cart cartt)
        {
            cartt.DateAndTimeE = vm.DateAndTimeE;
            cartt.DateAndTimeS = vm.DateAndTimeS;
            cartt.seatno = vm.seatno;
            cartt.ShowId = vm.ShowId;
            cartt.UserId = vm.UserId;
            cartt.Id = vm.Id;
            cartt.Cost = vm.Cost;
            _context.Cart.Remove(cartt);
            _context.SaveChanges();


             return RedirectToAction("Index", "Home");

        }


        public IActionResult Index()
        {
            string h1;
            var getMovieList = _context.MovieDetails.ToList();
            foreach(var item in getMovieList)
            {
                item.Cshow = _context.ShowTimes.Where(a=>a.Id==item.Id && a.DateAndTimeS>DateTime.Now).Count();
                _context.MovieDetails.Update(item);
            }

            
            _context.SaveChanges();
            ViewBag.us = _userManager.GetUserId(HttpContext.User);
            
            if(_userManager.GetUserId(HttpContext.User) == "cbc75238-1546-43be-a8f6-2689265dcc42")
            {
                return RedirectToAction("admin", "Admin");
            }



            return View("Index", getMovieList);


        }

        public IActionResult Index1()
        {
            string h1;
            var getMovieList = _context.MovieDetails.ToList();
            foreach (var item in getMovieList)
            {
                item.Cshow = _context.ShowTimes.Where(a => a.Id == item.Id && a.DateAndTimeS > DateTime.Now).Count();
                _context.MovieDetails.Update(item);
            }
            _context.SaveChanges();
            ViewBag.us = _userManager.GetUserId(HttpContext.User);

            h1 = Request.Form["h1"];
            switch (h1)
            {
                case "1":
                    var s = from item in getMovieList
                            where item.category == "action"
                            select item;
                    return View("Index", s);

                case "2":
                    var s1 = from item in getMovieList
                            where item.category == "drama"
                            select item;
                    return View("Index", s1);
                case "3":
                    var s2 = from item in getMovieList
                             where item.category == "comedy"
                             select item;
                    return View("Index", s2);
                case "4":
                    var s3 = from item in getMovieList
                             where item.category == "kids"
                             select item;
                    return View("Index", s3);
                case "5":
                    var s4 = from item in getMovieList
                             where item.category == "romance"
                             select item;
                    return View("Index", s4);
                case "6":
                    var s5 = getMovieList.OrderByDescending(a => a.Rating);
                    return View("Index", s5);

                case "7":
                    var s6 = getMovieList.OrderBy(a => a.Rating);
                    return View("Index", s6);

                default:
                    return View("Index",getMovieList);

            }

        }


        public IActionResult Contact()
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
            var model = _context.ShowTimes.Where(p => p.Id == id && p.DateAndTimeS > DateTime.Now );
            ViewBag.id = id;
            

            return View(model);
        
        }
        public IActionResult Ordered(int id)
        {
            string h;
            ViewBag.id = id;

            var model = _context.ShowTimes.Where(p => p.Id == id && p.DateAndTimeS > DateTime.Now);


            h = Request.Form["h"];
            switch (h)
            {
                case "1":
                    var s = model.OrderByDescending(a => a.Cost);
                    return View("Details", s);

                case "2":
                    var s1 = model.OrderBy(a => a.Cost);
                    return View("Details", s1);

                default:
                    return View("Details", model);

            }



        }


    }
}
