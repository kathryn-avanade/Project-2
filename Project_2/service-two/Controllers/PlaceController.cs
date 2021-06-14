using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace service_two.Controllers
{
    [ApiController]
    
    public class PlaceController : ControllerBase
    {
        //Set up an array with places the service can choose from randomly 
        private static readonly string[] Places = new[]
        {
            "in a shed", 
            "in a cave", 
            "under the sea", 
            "at the top of Mount Everest", 
            "in space", 
            "at the Grand Canyon", 
            "on an Alpaca farm", 
            "on a cliff by the ocean", 
            "on a roof top in New York", 
            "in a cathedral in Barcelona"
        };
        private static readonly string[] PlaceImages = new[]
        {
            "https://th.bing.com/th/id/R6d91f6cada4f5a584875c8fa8282f7d7?rik=bgIqWvLeBAMhpw&pid=ImgRaw",
            "https://th.bing.com/th/id/OIP.TCiVlj93FPCFLHSvlbCUogHaE6?pid=ImgDet&rs=1",
            "https://th.bing.com/th/id/R4f64a8c67d7107b7e099fdb1fa5274d9?rik=lBrLfWAI24ijLg&riu=http%3a%2f%2fgeographical.co.uk%2fimages%2farticles%2fnature%2fgeophoto%2f2017%2funder_the_sea%2fshutterstock_269208791.jpg&ehk=POMF20W%2fOA6XvbEZ20jKyCBd2h344g58oq8sA2QBujM%3d&risl=&pid=ImgRaw",
            "https://th.bing.com/th/id/Rdf24d5dd639b58cef77f95eb3715376b?rik=SO2MO7RTETWt4Q&pid=ImgRaw",
            "https://wallpaperboat.com/wp-content/uploads/2019/12/outer-space-11.jpg",
            "https://blog.assets.traveltrivia.com/2019/05/Grand-Canyon-Old.jpg",
            "https://th.bing.com/th/id/Refa4a8be02bbf0b1b1a4005401ca2fe3?rik=jB%2boYAN%2b%2f7mTvA&pid=ImgRaw",
            "https://th.bing.com/th/id/OIP.L9_pcbsugfOP8AAekcPekgHaFj?pid=ImgDet&rs=1",
            "https://th.bing.com/th/id/R31d5e275a19711a9e11bfa2a467832f5?rik=2yksVXh5P4koIg&pid=ImgRaw",
            "https://images.fineartamerica.com/images-medium-large-5/barcelona-cathedral-in-the-evening-artur-bogacki.jpg"
        };

        //Generate random index, save it for use until the user refreshes 

        private static int random;

        //public int Random
        //{
        //    get
        //    {
        //        return random;
        //    }
        //    set
        //    {
        //        Random r = new Random();
        //        int rdm = r.Next(0, Places.Length - 1);
        //        random = rdm;
        //    }

        //}
       
        

        [Route("[controller]")]
        [HttpGet]
        //Generate a random place by looking in a random index of the array
        public ActionResult<String> Get()
        {
            Random r = new Random();
            int rdm = r.Next(0, Places.Length - 1);
            random = rdm;
            return Places[random];
        }

        [Route("[controller]/{place}")]
        [HttpGet]
        public ActionResult<String> GetURL(string place)
        {
            //var index = Array.FindIndex(Places, item => item.Contains(place));
            //Find the right place in places 
            return PlaceImages[random];
        }
    }
}
