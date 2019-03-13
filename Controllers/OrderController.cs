using Microsoft.AspNetCore.Mvc;

namespace Screend.Controllers
{
    public class OrderController : Controller
    {

        #region GetRoutes
        
        public IActionResult GetAll()
        {
            return Ok();
        }
        
        public IActionResult GetById()
        {
            return Ok();
        }
        
        #endregion

        #region PostRoutes

        public IActionResult Create()
        {
            return Ok();
        }

        #endregion
        

        
    }
}