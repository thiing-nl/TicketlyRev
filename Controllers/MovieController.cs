using Microsoft.AspNetCore.Mvc;

namespace Screend.Controllers
{
    public class MovieController : Controller
    {

        #region GetRoutes
        
        [HttpGet]
        [Route("/movies/")]
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
       
        #region DeleteRoutes

        public IActionResult Delete()
        {
            return Ok();
        }
        
        #endregion
        
    }
}