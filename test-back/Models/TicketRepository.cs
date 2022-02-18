using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_back.Interfaces;

namespace test_back.Models
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDBContent appDBContent;

        public TicketRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return appDBContent.Tickets;
        }

        public void Create(Ticket item)
        {
            appDBContent.Tickets.Add(item);
            appDBContent.SaveChanges();
        }
    }
}
