using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_back.Models
{
    public class Objects
    {
        public static void Initial(AppDBContent content)
        {
            content.Tickets.AddRange(
                new Ticket(1, "Лондон", "Париж", new DateTime(2022, 3, 15, 6, 15, 6), new DateTime(2022, 3, 16, 6, 15, 6), 567),
                new Ticket(2, "Москва", "Лондон", new DateTime(2022, 3, 17, 13, 15, 6), new DateTime(2022, 3, 18, 6, 15, 6), 567),
                new Ticket(3, "Лондон", "Москва", new DateTime(2022, 3, 12, 16, 15, 6), new DateTime(2022, 3, 13, 17, 15, 6), 567),
                new Ticket(4, "Париж", "Москва", new DateTime(2022, 3, 20, 21, 15, 6), new DateTime(2022, 3, 21, 6, 15, 6), 567)
            );
            content.SaveChanges();
        }
    }
}
