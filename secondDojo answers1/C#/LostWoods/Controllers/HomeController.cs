using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostWoods.Models;
using LostWoods.Factories;
using System.Data;
using MySql.Data.MySqlClient;

namespace LostWoods.Controllers
{

    public class HomeController : Controller
    {
        private readonly WoodsFactory _woodsFactory;
        public HomeController()
        {
            _woodsFactory = new WoodsFactory();
            //this instantiates it 
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index ()
        {
            ViewBag.Woods = _woodsFactory.GetAllWoods();
            // ViewBag.display = result;
            //use the underscore version when calling the function later in the doc
            //passes all dojos into the view
            return View();
        }

        [HttpGet]
        [Route("new_trail")]
        public IActionResult New_Trail()
        {
            Woods newTrail = new Woods();
            return View(newTrail);
        }

        [HttpPost]
        [Route("add_new")]
        public IActionResult newtrailadd(Woods newTrail)
        //this is the action that you add to the POST for the html file 
        {
            if (ModelState.IsValid) 
            {
                _woodsFactory.AddNew(newTrail);
                return RedirectToAction("Index");
            }
            else {
                return View("new_trail", newTrail);
            }
        }
    }
}

//         private readonly UserFactory userFactory;
//         public HomeController()
//         {
//             //Instantiate a UserFactory object that is immutable (READONLY)
//             //This establishes the initial DB connection for us.
//             userFactory = new UserFactory();
//         }
//         // GET: /Home/
//         [HttpGet]
//         [Route("")]
//         public IActionResult Index()
//         {
//             //We can call upon the methods of the userFactory directly now.
//             ViewBag.Users = userFactory.FindAll();
//             return View();
//         }
//     }
// }
