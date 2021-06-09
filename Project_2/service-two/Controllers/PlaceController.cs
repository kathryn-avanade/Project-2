using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace service_two.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceController : ControllerBase
    {
        private static readonly string[] Places = new[]
        {
            "a shed", "a cave", "under the sea", "at the top of Mount Everest", "in space", "at the Grand Canyon", "on an Alpaca farm", "on a cliff by the ocean", "on a roof top in New York", "in a cathedral in Barcelona"
        };

        

        [HttpGet]
        //Generate a random place 
        public ActionResult<String> Get()
        {
            Random r = new Random();
            int rdm = r.Next(0, 9);
            return Places[rdm];
        }
    }
}
