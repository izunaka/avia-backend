using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_back.Models;


namespace test_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly AppDBContent db;
        public CitiesController(AppDBContent db)
        {
            this.db = db;
        }

        /// <summary>
        /// Получение списка городов
        /// </summary>
        /// <returns>Список городов</returns>
        [HttpGet]
        public IEnumerable<City> Get()
        {
            return db.Cities.ToList();
        }

        /// <summary>
        /// Метод заполняет базу данных тестовыми городами
        /// </summary>
        [HttpPost]
        public void Post()
        {
            db.Cities.RemoveRange(db.Cities);
            db.Cities.AddRange(
                new City() { CityName = "Москва" },
                new City() { CityName = "Лондон" },
                new City() { CityName = "Сингапур" },
                new City() { CityName = "Дубай" },
                new City() { CityName = "Париж" },
                new City() { CityName = "Нью-Йорк" },
                new City() { CityName = "Рим" },
                new City() { CityName = "Токио" },
                new City() { CityName = "Стамбул" },
                new City() { CityName = "Сеул" },
                new City() { CityName = "Барселона" },
                new City() { CityName = "Лас-Вегас" },
                new City() { CityName = "Милан" },
                new City() { CityName = "Амстердам" },
                new City() { CityName = "Анталия" },
                new City() { CityName = "Вена" },
                new City() { CityName = "Лос-Анджелес" },
                new City() { CityName = "Берлин" },
                new City() { CityName = "Сан-Франциско" },
                new City() { CityName = "Будапешт" },
                new City() { CityName = "Мюнхен" },
                new City() { CityName = "Санкт-Петербург" },
                new City() { CityName = "Вашингтон" },
                new City() { CityName = "Новосибирск" }
            );
            db.SaveChanges();
           
        }
    }
}
