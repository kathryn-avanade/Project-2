using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace service_three.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeddingController : ControllerBase
    {
        //dependency injection
        private IConfiguration Configuration;
        public WeddingController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var PersonService = $"{Configuration["personServiceURL"]}/person";
            var serviceOneResponseCall = await new HttpClient().GetStringAsync(PersonService);
            
            var PlaceService = $"{Configuration["placeServiceURL"]}/place";
            var serviceTwoResponseCall = await new HttpClient().GetStringAsync(PlaceService);

            var serviceThreeResponse = $"Your dream wedding is with {serviceOneResponseCall} in {serviceTwoResponseCall}";
            return Ok(serviceThreeResponse);
        }


    }
}
