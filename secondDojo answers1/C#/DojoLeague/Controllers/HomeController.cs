using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoLeague.Models;
using DojoLeague.Factories;
using System.Data;
using MySql.Data.MySqlClient;

namespace DojoLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly DojoFactory _dojofactory;
        public HomeController()
        {
            _dojofactory = new DojoFactory();
            //this instantiates it 
        }
        [HttpGet]
        [Route("")]

        public IActionResult Index ()
        {
            ViewBag.Dojos = _dojofactory.GetAllDojos();
            //passes all dojos into the view
            return View();
        }
     
        [HttpGet]
        [Route("dojos")]
        public IActionResult Dojos()
        {
            Dojo newDojo = new Dojo();
            return View(newDojo);
        }

        [HttpPost]
        [Route("add_new")]
        public IActionResult newdojoadd(Dojo newDojo)
        //this is the action that you add to the POST for the html file 
        {
            if (ModelState.IsValid) 
            {
                _dojofactory.AddDojo(newDojo);
                return RedirectToAction("Index");
            }
            else {
                ViewBag.Dojos = _dojofactory.GetAllDojos();
                return View("dojos", newDojo);
            }
        }

        [HttpGet]
        [Route("dojos/{id}/")]
        public IActionResult showdojo(int id){
            System.Console.WriteLine(id);
            ViewBag.dojo = _dojofactory.GetDojoById(id);
            // ViewBag.rogues = dojofactory.GetRogueNinjas();

            return View("dojoshow", id);
        }

        // [HttpPost]
        // [Route("add_ninja")]
        // public IActionResult NewNinjaAdd(Ninja newNinja)
        // //this is the action that you add to the POST for the html file 
        // {
        //     if (ModelState.IsValid) 
        //     {
        //         _dojofactory.AddNinja(newNinja);
        //         return RedirectToAction("Index");
        //     }
        //     else {
        //         return View("index", newNinja);
        //     }
        // }

    }
}


   // public IActionResult About()
        // {
        //     ViewData["Message"] = "The application description page.";
        //     return View();
