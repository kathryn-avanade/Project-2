using Frontend.Controllers;
using Frontend.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using RichardSzalay.MockHttp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Project_2.Tests
{
    public class HomeControllerTest
    {
        //Arrange
        //Create mock objects to pass to the home controller when its instantiated
        private HomeController homeController;
        private Mock<ILogger<HomeController>> logger;
        private Mock<IConfiguration> config;
        private Mock<IRepoWrapper> mockRepo;
        private Wedding wedding;

        public HomeControllerTest()
        {
            logger = new Mock<ILogger<HomeController>>();
            config = new Mock<IConfiguration>();
            mockRepo = new Mock<IRepoWrapper>();
            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://localhost:17702/wedding").Respond("text/plain", "");
            mockHttp.When("http://localhost:17702/wedding/person").Respond("text/plain", "");
            mockHttp.When("http://localhost:17702/wedding/place/something").Respond("text/plain", "");
            var client = new HttpClient(mockHttp);
            homeController = new HomeController(logger.Object, config.Object, client, mockRepo.Object);

        }

        [Fact]
        public void IndexMethod_Returns_View()
        {
            //Arrange
            //The mock objects have been arranged above to be passed to the new local
            // HomeController object which will be tested on
            //Mock the http requests
            

            //Act
            //Call the index method on the local HomeController object
            var result = homeController.Index();
            //Assert
            //Check that this method returns correct type
            Assert.IsType<Task<IActionResult>>(result);
        }
        [Fact]
        public void AddMethodReturnsWedding()
        {
            //Arrange 
            string personURL = "www.myperson.com";
            string placeURL = "www.myplace.com";
            string serviceThree = "Your dream wedding is with person in place";
            

            //Act
            var result = homeController.Add(serviceThree, personURL, placeURL);
            //Assert
            Assert.IsType<Wedding>(result);
        }

        
    }
}
