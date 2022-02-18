using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_back.Interfaces;
using test_back.Models;

namespace test_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        // GET: api/<TicketController>
        [HttpGet(Name = "GetAllItems")]
        public IEnumerable<Ticket> Get()
        {
            return _ticketRepository.GetTickets();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Ticket ticket)
        {
            if (ticket == null)
            {
                return BadRequest();
            }
            _ticketRepository.Create(ticket);
            return RedirectToRoute("GetAllItems");
        }
    }
}
