using Frontend.Data;
using Frontend.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class WeddingsController : Controller
    {
        private IRepoWrapper _repo;
        //Dependancy injection
        public WeddingsController(IRepoWrapper repoWrapper)
        {
            _repo = repoWrapper;
        }
        public IActionResult Index()
        {
            var allWeddings = _repo.Weddings.FindAll();
            return View(allWeddings);
        }
    }
}
