using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_back.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace test_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly AppDBContent db;
        public TicketsController(AppDBContent db)
        {
            this.db = db;
        }

        /// <summary>
        /// Метод для получения билетов на авиарейсы по заданным параметрам
        /// </summary>
        /// <param name="from">Город вылета</param>
        /// <param name="to">Город прибытия</param>
        /// <param name="dep">Дата вылета</param>
        /// <param name="arr">Дата прибытия</param>
        /// <returns>Список билетов</returns>
        [HttpGet]
        public IEnumerable<Ticket> Get(int? from = null, int? to = null, DateTime? dep = null, DateTime? arr = null)
        {
            var tickets = db.Tickets
                .Include(e => e.FromCity)
                .Include(e => e.ToCity)
                .Where(e => (
                    (from == null || e.FromCity.Id == from) &&
                    (to == null || e.ToCity.Id == to)
                ));

            if (dep != null)
            {
                var cmpDate = dep.Value;
                tickets = tickets.Where(e => (e.DepDate.Year == cmpDate.Year && e.DepDate.Month == cmpDate.Month && e.DepDate.Day == cmpDate.Day));
            }

            if (arr != null)
            {
                var cmpDate = arr.Value;
                tickets = tickets.Where(e => (e.ArrDate.Year == cmpDate.Year && e.ArrDate.Month == cmpDate.Month && e.ArrDate.Day == cmpDate.Day));
            }

            var res = tickets.ToArray();

            return res;
        }

        /// <summary>
        /// Метод заполняет базу данных тестовыми данными. Билеты формируются на самые популряные города мира
        /// (Москва, Лондон, Париж и др. - см метод Post контроллера Citites) на даты следующего месяца с 10 по 19 число
        /// </summary>
        [HttpPost]
        public void Post()
        {
            db.Tickets.RemoveRange(db.Tickets);
            List<City> cities = db.Cities.ToList();
            int month = DateTime.Now.Month % 12 + 1;
            int year = month == 1 ? DateTime.Now.Year + 1 : DateTime.Now.Year;
            Random rand = new Random();
            for (int day = 10; day < 20; day++)
            {
                foreach (var city1 in cities)
                {
                    foreach (var city2 in cities)
                    {
                        if (city1.CityName != city2.CityName)
                        {
                            for (int j = 0; j < 10; j++)
                            {
                                db.Tickets.Add(new Ticket()
                                {
                                    DepDate = new DateTime(year, month, day, rand.Next(0, 24), rand.Next(0, 60), 0),
                                    ArrDate = new DateTime(year, month, day + 1, rand.Next(0, 24), rand.Next(0, 60), 0),
                                    FromCity = city1,
                                    ToCity = city2,
                                    Cost = rand.Next(1000, 40000),
                                    IsRefundable = (rand.Next(0, 2) == 0),
                                    Seats = rand.Next(10, 60)
                                });
                            }
                        }
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
