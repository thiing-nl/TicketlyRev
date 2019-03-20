using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Screend.Entities.Ticket;
using Screend.Models.Ticket;
using Screend.Repositories;
using Screend.Services;

namespace Screend.Controllers
{
    [Route("/api/tickets")]
    public class TicketController : BaseController
    {

        private readonly ITicketService _ticketService;
        
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{scheduleId}")]
        [ProducesResponseType(typeof(ICollection<TicketDTO>),StatusCodes.Status200OK)]
        public IActionResult GetTicketsBySchedule(int scheduleId)
        {
            ICollection<Ticket> tickets = _ticketService.GetTicketsBySchedule(scheduleId);
            return Ok(Mapper.Map<ICollection<TicketDTO>>(tickets));
        }
        
    }
}