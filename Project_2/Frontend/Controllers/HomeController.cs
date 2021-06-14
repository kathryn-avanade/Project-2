using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        //Dependancy injection 
        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        //As await is used, this method needs to have the async keyword 
        //The return type is Task<IActionResult> because 
        public async Task<IActionResult> Index()
        {
            //This line is used to find the controller in the api, it gets the controller name from the keyvalue of the 
            //route dictionary (any case) i.e. by writing /wedding it looks for WeddingController
            var Service3 = $"{Configuration["Service3URL"]}/wedding";
            var serviceThreeResponseCall = await new HttpClient().GetStringAsync(Service3);
            //Wedding result to show on webpage using viewbag 
            ViewBag.responseCall = serviceThreeResponseCall;

            //Get person image url
            var Service3PersonURL = $"{Configuration["Service3URL"]}/wedding/person";
            var serviceThreeURLPerson = await new HttpClient().GetStringAsync(Service3PersonURL);
            ViewBag.personURL = serviceThreeURLPerson;

            //Get place image url
            var Service3PlaceURL = $"{Configuration["Service3URL"]}/wedding/place/something";
            var serviceThreeURLPlace = await new HttpClient().GetStringAsync(Service3PlaceURL);
            ViewBag.placeURL = serviceThreeURLPlace;

            return View();
        }

     
        //Error view page 
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



       
        






    }
}
