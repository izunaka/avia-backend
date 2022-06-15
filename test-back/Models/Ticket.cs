using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_back.Models
{
    public class Ticket
    {
        public long Id { get; set; }

        public City FromCity { get; set; }

        public City ToCity { get; set; }

        public DateTime DepDate { get; set; }

        public DateTime ArrDate { get; set; }

        public double Cost { get; set; }

        public int Seats { get; set; }

        public bool IsRefundable { get; set; }
    }
}
