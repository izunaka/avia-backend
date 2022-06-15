using Microsoft.AspNetCore.Http;
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
    public class DocTypesController : ControllerBase
    {
        private readonly AppDBContent db;

        public DocTypesController(AppDBContent db)
        {
            this.db = db;
        }

        [HttpPost]
        public void Post()
        {
            if (db.DocTypes.ToArray().Length == 0)
            {
                db.DocTypes.AddRange(
                    new DocType() { DocCode = "ПС", DocName = "Паспорт" },
                    new DocType() { DocCode = "СР", DocName = "Свидетельство о рождении" },
                    new DocType() { DocCode = "ПСП", DocName = "Заграничный паспорт" }
                );
                db.SaveChanges();
            }
        }
    }
}
