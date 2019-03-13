using Microsoft.AspNetCore.Mvc;

namespace Screend.Controllers
{
    public class ScheduleController : BaseController
    {
        
        #region GetRoutes

        public IActionResult GetByDay()
        {
            return Ok();
        }

        public IActionResult GetByWeek()
        {
            return Ok();
        }
        
        #endregion
        
    }
}