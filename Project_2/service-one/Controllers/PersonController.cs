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

    public class PersonController : ControllerBase
    {
        //Set up an array with people the service can choose from randomly 
        private static readonly string[] People = new[]
        {
            "Boris Johnson", "Kanye West", "James Dean", "Danny DeVito", "Will Smith","Nicki Minaj","Miley Cyrus","Theresa May", "Katie Hopkins", "Halle Berry", 
        };
        //Hopefully I can fill this with urls 
        private static readonly string[] PeopleImages = new[]
        {
            "https://www.hellofaread.com/wp-content/uploads/2019/11/NINTCHDBPICT000542205321-e1574545322359.jpg",
            "https://th.bing.com/th/id/R0e630b5303c2f86ceed80da5019cd63b?rik=ibnBCobtoM5RjA&pid=ImgRaw",
            "https://th.bing.com/th/id/R29c21661af4d169d258a2a0b28b09878?rik=TcVBV9FjgutrBw&pid=ImgRaw",
            "https://th.bing.com/th/id/R911748f6958370a5ae85253ce38a2217?rik=Nmc3onGpVVCmqA&pid=ImgRaw",
            "https://th.bing.com/th/id/OIP.uF5SGWjOsAQ_ZpohqRXzpAHaL9?pid=ImgDet&rs=1",
            "https://i.pinimg.com/originals/b0/d3/ed/b0d3ed8cc8514eb2e557332c5743bd08.jpg",
            "https://th.bing.com/th/id/OIP.KWnUvzPMYHU5D97fFC_i7wHaE5?pid=ImgDet&rs=1",
            "https://th.bing.com/th/id/R6cab8f9b057913ea98e08ff80149f7b9?rik=KmaKJKl%2bRvCDsA&pid=ImgRaw",
            "https://th.bing.com/th/id/R0cd0882529d933d9642b3fa0e20c6215?rik=gwruAwZoAIHiZA&pid=ImgRaw",
            "https://th.bing.com/th/id/R008e99c31264e392f54d5eb9e25ad650?rik=QKUnHP%2bCc%2fGR2Q&pid=ImgRaw",
            
        };


        private static int random;
        
        [Route("[controller]")]
        [HttpGet]
        public ActionResult<String> Get()
        {
            Random r = new Random();
            int rdm = r.Next(0, People.Length - 1);
            random = rdm;
            return People[random];

        }

        [Route("[controller]/{person}")]
        [HttpGet]
        public ActionResult<String> GetURL(string person)
        {
            return PeopleImages[random];
        }
    }
}
