using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using RichardSzalay.MockHttp;
using service_three.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            

            var mockHttp = new MockHttpMessageHandler();
            mockHttp.When("http://localhost:41446/person").Respond("text/plain", "");
            mockHttp.When("http://localhost:54757/place").Respond("text/plain", "");
            mockHttp.When("http://localhost:41446/person/person").Respond("text/plain", "");
            mockHttp.When("http://localhost:54757/place/place").Respond("text/plain", "");
            var client = new HttpClient(mockHttp);

            weddingController = new WeddingController(config.Object, client);
        }

        [Fact]
        public void TestWeddingControllerIndexMethod()
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
        [Fact]
        public void TestWeddingControllerGetURLpersonMethod()
        {
            //act
            var result = weddingController.GetURLperson();
            //assert
            Assert.IsType<Task<IActionResult>>(result);

        }
        [Fact]
        public void TestWeddingControllerGetURLplaceMethod()
        {
            //act
            var result = weddingController.GetURLplace("");
            //assert
            Assert.IsType<Task<IActionResult>>(result);

        }
    }
}
