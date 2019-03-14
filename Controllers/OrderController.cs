using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Models.Order;

namespace Screend.Controllers
{
    [Route("api/orders")]
    public class OrderController : BaseController
    {

        #region GetRoutes

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }
       
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        
        #endregion

        #region PostRoutes

        [HttpPost("create")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] OrderCreateDTO orderCreateDto)
        {
            return Ok();
        }

        #endregion
        

        
    }
}