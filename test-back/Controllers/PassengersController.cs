using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using test_back.Models;


namespace test_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private readonly AppDBContent db;

        public PassengersController(AppDBContent db)
        {
            this.db = db;
        }

        [HttpGet]
        public IEnumerable<Passenger> Get()
        {
            return db.Passengers.ToArray();
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var passenger = db.Passengers.FirstOrDefault(e => e.Id == id);

            if (passenger == null)
            {
                return BadRequest("Пассажир не найден!");
            }

            return passenger;
        }

        [HttpPost]
        public object Post(string firstName, string surname, int age, string citizenship, 
            int docTypeId, string docNumber, int ticketId, bool isRefund = false)
        {
            var ticket = db.Tickets.FirstOrDefault(e => e.Id == ticketId);
            var docType = db.DocTypes.FirstOrDefault(e => e.Id == docTypeId);

            if (ticket == null)
            {
                return BadRequest("Данный билет не найден");
            }
            if (docType == null)
            {
                return BadRequest("Не найден указанный документ!");
            }
            if (!Regex.IsMatch(firstName, @"^[a-zA-ZА-Яа-я\'\-]{2, 16}$")
                || !Regex.IsMatch(surname, @"^[a-zA-ZА-Яа-я\'\-]{2, 16}$")
                || !Regex.IsMatch(docNumber, @"^[a-zA-ZА-Яа-я0-9\-]{2, 17}$")
                || !Regex.IsMatch(citizenship, @"^[a-zA-ZА-Яа-я\-]{2, 17}$")
                || age < 2 || age > 120)
            {
                return BadRequest("Введены некорректные личные данные!");
            }
            if (!ticket.IsRefundable && isRefund)
            {
                return BadRequest("Билет не является возвратным!");
            }

            db.Passengers.Add(new Passenger() { 
                FirstName = firstName,
                Surname = surname,
                Age = age,
                Citizenship = citizenship,
                DocType = docType,
                DocNumber = docNumber,
                BoughtTicket = ticket,
                IsRefund = isRefund
            });
            db.SaveChanges();

            return "Success";
        }

        [HttpPut("{id}")]
        public object Put(int id, string firstName = "", string surname = "", int age = -1, string citizenship = "",
            int docTypeId = -1, string docNumber = "", int ticketId = -1, bool? isRefund = null)
        {
            var passenger = db.Passengers.FirstOrDefault(e => e.Id == id);

            if (passenger == null)
            {
                return BadRequest("Пассажир не найден!");
            }

            var newFirstName = (firstName != "" ? firstName : passenger.FirstName);
            var newSurname = (surname != "" ? surname : passenger.Surname);
            var newAge = (age != -1 ? age : passenger.Age);
            var newCitizenship = (citizenship != "" ? citizenship : passenger.Citizenship);
            var newDocNumber = (docNumber != "" ? docNumber : passenger.DocNumber);
            var newIsRefund = (isRefund != null ? isRefund.Value : passenger.IsRefund);

            var ticket = (ticketId != -1 ? db.Tickets.FirstOrDefault(e => e.Id == ticketId) : passenger.BoughtTicket);
            var docType = (docTypeId != -1 ? db.DocTypes.FirstOrDefault(e => e.Id == docTypeId) : passenger.DocType);

            if (ticket == null)
            {
                return BadRequest("Данный билет не найден");
            }
            if (docType == null)
            {
                return BadRequest("Не найден указанный документ!");
            }
            if (!Regex.IsMatch(newFirstName, @"^[a-zA-ZА-Яа-я\'\-]{2, 16}$")
                || !Regex.IsMatch(newSurname, @"^[a-zA-ZА-Яа-я\'\-]{2, 16}$")
                || !Regex.IsMatch(newDocNumber, @"^[a-zA-ZА-Яа-я0-9\-]{2, 17}$")
                || !Regex.IsMatch(newCitizenship, @"^[a-zA-ZА-Яа-я\-]{2, 17}$")
                || newAge < 2 || newAge > 120)
            {
                return BadRequest("Введены некорректные личные данные!");
            }
            if (!ticket.IsRefundable && newIsRefund)
            {
                return BadRequest("Билет не является возвратным!");
            }

            passenger.FirstName = newFirstName;
            passenger.Surname = newSurname;
            passenger.Age = newAge;
            passenger.DocType = docType;
            passenger.BoughtTicket = ticket;
            passenger.Citizenship = newCitizenship;
            passenger.DocNumber = newDocNumber;
            passenger.IsRefund = newIsRefund;

            return "Success";
        }

        [HttpDelete("{id}")]
        public object Delete(int id)
        {
            var passenger = db.Passengers.FirstOrDefault(e => e.Id == id);

            if (passenger == null)
            {
                return BadRequest("Пассажир не найден!");
            }

            db.Passengers.Remove(passenger);

            return "Success";
        }
    }
}
