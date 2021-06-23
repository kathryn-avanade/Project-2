using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using service_three;
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

        private AppSettings appSettings = new AppSettings()
        {
            personServiceURL = "https://functionservice1.azurewebsites.net",
            placeServiceURL = "https://functionservice2.azurewebsites.net"

        };
        public WeddingControllerTest()
        {
            
            config = new Mock<IConfiguration>();
            var options = new Mock<IOptions<AppSettings>>();
            options.Setup(x => x.Value).Returns(appSettings);
            weddingController = new WeddingController(options.Object);
        }

        //[Fact]
        //public async void TestWeddingControllerIndexMethod()
        //{
        //    //Arrange
        //    //The mock objects have been arranged above to be passed to the new local
        //    //WeddingController object which will be tested on 

        //    //Act
        //    //Call the Get method on the local HomeController object 
        //    var result = await weddingController.Get();

        //    //Assert 
        //    //Check the get method returns something of type string
        //    Assert.IsType<OkObjectResult>(result);
        //}
        //[Fact]
        //public async void TestWeddingControllerGetURLpersonMethod()
        //{
        //    var result = await weddingController.GetURLperson();
        //    Assert.IsType<OkObjectResult>(result);
        // }
        //[Fact]
        //public async void TestWeddingControllerGetURLplaceMethod()
        //{
        //    //act
        //    var result = await weddingController.GetURLplace("");
        //    //assert
        //    Assert.IsType<OkObjectResult>(result);

        //}
    }
}
