using Frontend;
using Frontend.Controllers;
using Frontend.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
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
       

        private AppSettings appSettings = new AppSettings()
        {
            Service3URL = "https://functionservice3.azurewebsites.net",
            
        };
        public HomeControllerTest()
        {
            logger = new Mock<ILogger<HomeController>>();
            config = new Mock<IConfiguration>();
            mockRepo = new Mock<IRepoWrapper>();
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            homeController = new HomeController(logger.Object, options.Object, mockRepo.Object);
            
        }

        //[Fact]
        //public async void IndexMethod_Returns_View()
        //{
        //    //Arrange
        //    //The mock objects have been arranged above to be passed to the new local
        //    // HomeController object which will be tested on

        //    //Act
        //    //Call the index method on the local HomeController object
        //    var result =  await homeController.Index();
        //    //Assert
        //    //Check that this method returns correct type
        //    Assert.IsType<OkObjectResult>(result);
        //}
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
