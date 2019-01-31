using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace DojoSurvey.Controllers
{
    public class HomeController : Controller 
    {
        [HttpGet]
        [Route ("")]
        public IActionResult Index()
        {
            return View("Index");
        }
    
        
        [HttpPost]
        [Route("userformsubmit")]
        public IActionResult UserFormSubmit(string name, string location, string language, string message)
        {
            ViewBag.name = name;
            ViewBag.location = location; 
            ViewBag.language = language; 
            ViewBag.message = message;
            return View("Result");
        }
    }
    
}