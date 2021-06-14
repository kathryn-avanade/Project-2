using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using service_three.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project_2.Tests
{
    public class WeddingControllerTest
    {
        private WeddingController weddingController;
        private Mock<IConfiguration> config;

        public WeddingControllerTest()
        {
            
            config = new Mock<IConfiguration>();
            weddingController = new WeddingController(config.Object);
        }

        [Fact]
        public void ActionMethod_Returns_String()
        {
            //Arrange
            //The mock objects have been arranged above to be passed to the new local
            //WeddingController object which will be tested on 

            //Act
            //Call the Get method on the local HomeController object 
            var result = weddingController.Get();

            //Assert 
            //Check the get method returns something of type string
            Assert.IsType<Task<IActionResult>>(result);
        }
    }
}
