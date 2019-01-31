
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using WeddingPlanner.Data;
using WeddingPlanner.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace WeddingPlanner.Controllers
{
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController (DataContext context)
        {
            _context = context;
        }   
 

        [HttpGet("")]
        public IActionResult Index()
        {
            ///you can return view if they match exactly - index and index esxample
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            ///will render register template
            return View();
        }

        [HttpGet("showdashboard")]
        public IActionResult Dash()
        {
            ///will render register template
            return View();
        }


        [HttpPost]
        [Route("register")]
        public IActionResult Register(AuthViewModel newUser)
        {   
            ///if model state is not valid, back to the previous page
            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                User Usercheck = _context.Users.SingleOrDefault(u => u.Email == newUser.RegForm.Email );
                if (Usercheck != null)
                {
                    ViewBag.EmailExists = "That user already exists.";
                    return View();
                } 
                else{
                    PasswordHasher<RegisterViewModel> hasher = new PasswordHasher<RegisterViewModel>();
                    string HashedPW = hasher.HashPassword(newUser.RegForm, newUser.RegForm.Password);
                    User NewUser = new User
                    {
                    FirstName = newUser.RegForm.FirstName,
                    LastName = newUser.RegForm.LastName,
                    Email = newUser.RegForm.Email,
                    Password = HashedPW,
                    };

                    _context.Add(NewUser);
                    _context.SaveChanges();
                    User loggedin = _context.Users.SingleOrDefault(u => u.Email == newUser.RegForm.Email);
                    HttpContext.Session.SetInt32("UserId", loggedin.UserId);
                    return RedirectToAction("Dash");
                }
            }
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login (AuthViewModel ReturnUser)
        {
            if(!ModelState.IsValid)
            {
                return View("Register");
                ///this is where the form is now
            }
            else{
                User LoggingIn = _context.Users.SingleOrDefault(user =>user.Email == ReturnUser.LoginForm.Email);
                if (LoggingIn == null)
                {
                ViewBag.Nouser = "You could not be logged in.";
                return View ("Register");
            }
            // else
            // {
            //     // User LoggedIn = _context.Users.
            // }
            return View ("Register");
        }
    }
    }
}