using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Portfolio2.Controllers
{
    public class ContactController : Controller 
    {
        [HttpGet]
        [Route ("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }

    }
    
}