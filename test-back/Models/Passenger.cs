using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_back.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Citizenship { get; set; }

        public DocType DocType { get; set; }

        public string DocNumber { get; set; }

        public Ticket BoughtTicket { get; set; }

        public bool IsRefund { get; set; }
    }
}
