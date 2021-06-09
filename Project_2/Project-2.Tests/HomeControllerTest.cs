using Frontend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace Project_2.Tests
{
    public class HomeControllerTest
    {

        //private HomeController homeController;
        private Mock<ILogger<HomeController>> logger;
        private HomeController homeController;
        private Mock<IConfiguration> config;

        public HomeControllerTest()
        {
            logger = new Mock<ILogger<HomeController>>();
            config = new Mock<IConfiguration>();
            homeController = new HomeController(logger.Object,config.Object);
        }

        [Fact]
        public void IndexMethod_Returns_View()
        {
            //Arrange
            //The mock objects have been arranged above to be passed to the new local
            // HomeController object which will be tested on 
            
            //Act
            //Call the index method on the local HomeController object 
            var result = homeController.Index();
            //Assert
            //Check that this method returns a viewresult 
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void ErrorMethod_Returns_View()
        {
            //Arrange
            //The mock objects have been arranged above to be passed to the new local
            // HomeController object which will be tested on 

            //Act
            //Call the error method on the local HomeController object 
            var result = homeController.Error();

            //Assert
            //Check that this method returns a viewresult 
            Assert.IsType<ViewResult>(result);
        }
    }
}
