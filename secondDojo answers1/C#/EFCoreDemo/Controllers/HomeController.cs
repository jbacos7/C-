using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCoreDemo.Models;
using System.Data;
using MySql.Data.MySqlClient;

namespace EFCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context; 

        public HomeController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<User> AllUsers = _context.Users.ToList();
            return View();
        }
    }
}