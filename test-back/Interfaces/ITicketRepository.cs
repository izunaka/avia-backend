using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_back.Models;

namespace test_back.Interfaces
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetTickets();
        void Create(Ticket item);
    }
}
