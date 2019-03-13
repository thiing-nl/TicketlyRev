using Microsoft.AspNetCore.Mvc;

namespace screend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
