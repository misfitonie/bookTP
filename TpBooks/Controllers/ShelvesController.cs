using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TpBooks.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelvesController : ControllerBase
    {

        private static Shelvesdto _shelves = new Shelvesdto();
        private static Bookdto _book = new Bookdto();

        [HttpGet]
        public ActionResult<Shelvesdto> Get(int id)
        {
            if (_shelves is null)
            {
                return NotFound();
            }

            return Ok(_shelves.GetShelves(id));
        }
    }
}