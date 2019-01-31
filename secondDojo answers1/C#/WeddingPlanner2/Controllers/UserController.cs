using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using WeddingPlanner2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using WeddingPlanner2.Data;

namespace WeddingPlanner2.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("register")]
        public IActionResult registerpage()
        {
            return View("Register");
        }


        [HttpGet]
        [Route("login")]
        public IActionResult loginpage()
        {
            System.Console.WriteLine("\n\n\t===   START \n\n" );
            return View("Login");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string loginemail, string loginpw)
        {
            var Hasher = new PasswordHasher<User>();
            User usercheck = _context.Users.SingleOrDefault(user => user.Email == loginemail);


            if (usercheck == null || loginpw == null ) 
            {
                ViewBag.Message = "You could not be logged in. Please try again.";
                return View("Login");
            }
            else
            {
                if (0 == Hasher.VerifyHashedPassword(usercheck, usercheck.Password, loginpw)){
                ViewBag.Message = "You could not be logged in. Please try again.";
                return View("Login");}
                
                var activeuser = _context.Users.SingleOrDefault(user => user.Email == loginemail);
                HttpContext.Session.SetString("Loggedinuser", activeuser.FirstName + " " + activeuser.LastName);
                HttpContext.Session.SetInt32("UserId", usercheck.UserId);
                return RedirectToAction("Dashboard");
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel adduser)
        {
            if (ModelState.IsValid)
            {
                User UserInDB = _context.Users.SingleOrDefault(user => user.Email == adduser.Email);
                if (UserInDB != null)
                {
                    ViewBag.Message = "This email already exists in the database.";
                    return View("Register", adduser);
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User AddUserinDB = new User
                {
                    FirstName = adduser.FirstName,
                    LastName = adduser.LastName,
                    Email = adduser.Email,
                    Password = adduser.Password,
                };
                AddUserinDB.Password = Hasher.HashPassword(AddUserinDB, AddUserinDB.Password);
                _context.Add(AddUserinDB);
                _context.SaveChanges();
                AddUserinDB = _context.Users.SingleOrDefault(user => user.Email == AddUserinDB.Email);

                var activeuser = _context.Users.SingleOrDefault(user => user.Email == adduser.Email);
                HttpContext.Session.SetString("Loggedinuser", activeuser.FirstName + " " + activeuser.LastName);
                HttpContext.Session.SetInt32("UserId", AddUserinDB.UserId);
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Register", adduser);
            }
        }

        [HttpGet]
        [Route("weddingdashboard")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }
            List<Wedding> AllWeddings = _context.Weddings.Include(w => w.Guests).ThenInclude(g => g.User).ToList();

            User loginuser = _context.Users.SingleOrDefault(a => a.UserId == UserId);

            ViewBag.loginuser = loginuser;
            ViewBag.Weddings = AllWeddings;
            ViewBag.UserId = UserId;

            System.Console.WriteLine("\n\n\t==="+ ViewBag.UserId);

            HttpContext.Session.SetInt32("UserId", loginuser.UserId);
            HttpContext.Session.SetString("UserName", loginuser.FirstName);
            ViewBag.Loggedinuser = HttpContext.Session.GetString("Loggedinuser");
            
            return View();
        }

        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [HttpGet]
        [Route("addnew")]
        public IActionResult AddAWedding()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }
            TempData["UserId"] = UserId;
            return View("AddNew");
        }


        [HttpPost]
        [Route("AddNew")]
        public IActionResult CreateWedding(WeddingViewModel AddNewWedding, int UserId)
        {
            System.Console.WriteLine("##################################################");
            System.Console.WriteLine(AddNewWedding.WedderOne);
            System.Console.WriteLine(AddNewWedding.WedderOne);
            System.Console.WriteLine(AddNewWedding.Date);
            System.Console.WriteLine(AddNewWedding.Address);
            System.Console.WriteLine("##################################################");
            System.Console.WriteLine("\n\n\t=== + IN create wedding action    ==== \n\n");
            if (ModelState.IsValid)
            {
                // System.Console.WriteLine("\n\n\t=== + IN WEDDING CREATE NEW    ==== \n\n");
                Wedding thiswedding = new Wedding
                {
                    WedderOne = AddNewWedding.WedderOne,
                    WedderTwo = AddNewWedding.WedderTwo,
                    Date = AddNewWedding.Date,
                    Address = AddNewWedding.Address,
                    User = _context.Users.SingleOrDefault(user => user.UserId == UserId)
                };
                System.Console.WriteLine("\n\n\t=== + IN WEDDING CREATE NEW    ==== \n\n");
                _context.Add(thiswedding);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            else
            {
                System.Console.WriteLine("\n\n\t=== + IN WEDDING ERRORS  ELSE    ==== \n\n");
                return View ("AddNew");
            }
        }

        [HttpGet]
        [Route("wedding/show/{WeddingId}")]
        public IActionResult Wedding(int WeddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            Wedding thisWedding = _context.Weddings
                .Include(w => w.Guests)
                .ThenInclude(a => a.User)
                .SingleOrDefault(p => p.WeddingId == WeddingId);
            ViewBag.ThisWedding = thisWedding;
            return View();
        }

        [HttpGet]
        [Route("wedding/rsvp/{WeddingId}")]
        public IActionResult RSVPWedding(int WeddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            Guest newRSVP = new Guest
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                WeddingId = WeddingId
            };
            User addguesttolist = _context.Users.SingleOrDefault(a => a.UserId == newRSVP.UserId);
            addguesttolist.Guests.Add(newRSVP);

            Wedding addguest = _context.Weddings.SingleOrDefault(a => a.WeddingId == newRSVP.WeddingId);
            addguest.Guests.Add(newRSVP);

            Guest rsvped = _context.Guests.SingleOrDefault(p => p.UserId == (int)HttpContext.Session.GetInt32("UserId") && p.WeddingId == WeddingId);
            if (rsvped == null)
            {
                // ViewBag.Guest = GuestLoggedIn;
                TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
                TempData["UserName"] = HttpContext.Session.GetString("UserName");
                _context.Add(newRSVP);
                _context.SaveChanges();
                System.Console.WriteLine(newRSVP.UserId);
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("wedding/unrsvp/{WeddingId}")]
        public IActionResult UnRSVP(int WeddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            TempData["UserId"] = HttpContext.Session.GetInt32("UserId");
            Guest RemoveRSVP = _context.Guests.SingleOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId") && a.WeddingId == WeddingId);
            if (RemoveRSVP != null)
            {
                _context.Guests.Remove(RemoveRSVP);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet]
        [Route("wedding/cancel/{WeddingId}")]
        public IActionResult Cancel(int WeddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId == null)
            {
                return RedirectToAction("Index");
            }

            Wedding todelete = _context.Weddings.SingleOrDefault(a => a.UserId == (int)HttpContext.Session.GetInt32("UserId") && a.WeddingId == WeddingId);
            if (todelete != null)
            {
                _context.Weddings.Remove(todelete);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }
    }
}