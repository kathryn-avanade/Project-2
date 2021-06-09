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

        private readonly ILogger<HomeController> _logger;
        private IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        //As await is used, this method needs to have the async keyword 
        public async Task<IActionResult> Index()
        {
            //need to rewrite 
            var Service3 = $"{Configuration["Service3URL"]}/wedding";
            var serviceThreeResponseCall = await new HttpClient().GetStringAsync(Service3);
            
            //wedding result to show on webpage 
            ViewBag.responseCall = serviceThreeResponseCall;

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
