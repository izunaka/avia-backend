using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_back.Models
{
    public class Ticket
    {
        public Ticket(long id, string from, string to, DateTime depDate, DateTime arrDate, double cost)
        {
            this.id = id;
            this.from = from;
            this.to = to;
            this.depDate = depDate;
            this.arrDate = arrDate;
            this.cost = cost;
        }
        public long id { get; set; }

        public string from { get; set; }

        public string to { get; set; }

        public DateTime depDate { get; set; }

        public DateTime arrDate { get; set; }

        public double cost { get; set; }
    }
}
