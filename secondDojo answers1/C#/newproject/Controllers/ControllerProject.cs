using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
namespace newproject.Controllers
{
    public class ControllerProject : Controller 
    {
        [HttpGet]
        [Route ("project")]
        public string Project()
        {
            return "Hello, you did it! This is the projects page.";
        }

    }
    
}