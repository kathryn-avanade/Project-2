using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Generates a random person from an array that will get combined by service three
//with a place from service two to create a string that will be seen by the user. 

namespace service_one.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static readonly string[] People = new[]
        {
            "Boris Johnson", "Brad Pitt", "James Dean", "Channing Tatum", "Harry Styles","Scarlet Johanson","Angelina Jolie","Theresa May", "Katie Hopkins", "Oprah Winfrey", ""
        };
        
        [HttpGet]
        public ActionResult<String> Get()
        {
            //Generate a random index number 
            Random r = new Random();
            int rdm = r.Next(0, 9);
            return People[rdm];
        }
    }
}
