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
    
    public class WeddingController : ControllerBase
    {
        //Dependency injection
        private IConfiguration Configuration;
        private HttpClient _client;

        public WeddingController(IConfiguration configuration, HttpClient client)
        {
            Configuration = configuration;
            _client = client;


        }
        

        [Route("[controller]")]
        [HttpGet]
        public async Task<IActionResult> Get()
        //A task is an object that represents some work that should be done.
        //The task can tell you if the work is completed and if the operation returns a result, the task gives you the result.
        //It is used when executing something in parallel, i.e. calling two other apis 
        {
            var PersonService = $"{Configuration["personServiceURL"]}/person";
            var serviceOneResponseCall = await _client.GetStringAsync(PersonService);

            var PlaceService = $"{Configuration["placeServiceURL"]}/place";
            var serviceTwoResponseCall = await _client.GetStringAsync(PlaceService);
            
            var serviceThreeResponse = $"Your dream wedding is with {serviceOneResponseCall} {serviceTwoResponseCall}";

            return Ok(serviceThreeResponse);
            //Ok method: ObjectResult that sets the 200 status code (means success) 
            //ObjectResult is an IActionResult that has content negotiation (supports various content types) built in.
        }


        [Route("[controller]/{person}")]
        [HttpGet]
        public async Task<IActionResult> GetURLperson() 
        {

            var PersonServiceURL = $"{Configuration["personServiceURL"]}/person/person";
            var serviceOneResponseCallURL = await _client.GetStringAsync(PersonServiceURL);
            return Ok(serviceOneResponseCallURL);
         
        }

        [Route("[controller]/{place}/{something}")]
        [HttpGet]
        public async Task<IActionResult> GetURLplace(string place)
        {

            var PlaceServiceURL = $"{Configuration["placeServiceURL"]}/place/place";
            var serviceTwoResponseCallURL = await _client.GetStringAsync(PlaceServiceURL);
            return Ok(serviceTwoResponseCallURL);

        }


    }
}
