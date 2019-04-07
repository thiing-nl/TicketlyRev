using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Screend.Entities.Location;
using Screend.Entities.Order;
using Screend.Exceptions;
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

        #region GetRoutes

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPaymentStatus(int id)
        { 
            using (var httpClient = new HttpClient())
            {                
                var order = _orderService.GetById(id);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer test_q3bD2tJp8eSNkMcsF37xKBNj3dVfaG");
                
                var result =
                    await httpClient.GetAsync("https://api.mollie.com/v2/payments/" + order.MollieId);

                var content = await result.Content.ReadAsStringAsync();
                
                dynamic decodedObject = JsonConvert.DeserializeObject(content);

                var isPaid = decodedObject.status == "paid";

                if (isPaid)
                {
                    _orderService.Update(new Order
                    {
                        Id = order.Id,
                        Paid = 1
                    });
                    
                    return Ok("paid");
                }

                return Ok("unpaid");
            }
        }
        
        #endregion
        
        #region PostRoutes

        [HttpPost("create")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] OrderCreateDTO orderCreateDto)
        {
            using (var httpClient = new HttpClient())
            {
                double.TryParse(orderCreateDto.Amount, out double amount);

                var link = "";
                var id = "";
                if (amount > 0)
                {
                    var request = JsonConvert.SerializeObject(new MolliePaymentDTO
                    {
                        description = "Ticketly payment",
                        redirectUrl = orderCreateDto.ReturnUrl,
                        amount = new MollieAmountDTO
                        {
                            currency = "EUR",
                            value = orderCreateDto.Amount
                        }
                    });
                
                    httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer test_q3bD2tJp8eSNkMcsF37xKBNj3dVfaG");
                
                    var result =
                        await httpClient.PostAsync(
                            "https://api.mollie.com/v2/payments", 
                            new StringContent(request, Encoding.UTF8, "application/json")
                        );

                    var content = await result.Content.ReadAsStringAsync();
                
                    dynamic decodedObject = JsonConvert.DeserializeObject(content);

                    link = decodedObject._links.checkout.href;
                    id = decodedObject.id.ToString();
                }
                
                var order = _orderService.Create(orderCreateDto, id);
                var mappedOrder = new OrderDTO();
                mappedOrder.Id = order.Id;
                mappedOrder.PaymentLink = link;
                return Ok(mappedOrder);
            }            
        }

        #endregion
        

        
    }
}