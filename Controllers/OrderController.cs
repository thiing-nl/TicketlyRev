using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Models.Order;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("api/orders")]
    public class OrderController : BaseController
    {

        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #region PostRoutes

        [HttpPost("create")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Create([FromBody] OrderCreateDTO orderCreateDto)
        {
            var order = _orderService.Create(orderCreateDto);
            return Ok(Mapper.Map<OrderDTO>(order));
        }

        #endregion
        

        
    }
}