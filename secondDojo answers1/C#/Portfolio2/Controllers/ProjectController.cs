using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace Portfolio2.Controllers
{
    public class ProjectController : Controller 
    {
        [HttpGet]
        [Route ("project")]
        public IActionResult Project()
        {
            return View("Project");
        }
    }
    
}