using Microsoft.AspNetCore.Mvc;
using service_two.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Project_2.Tests
{
    public class PlaceControllerTest
    {
        private PlaceController controller;
        public PlaceControllerTest()
        {
            //Arrange
            //Create local controller to test
            controller = new PlaceController();
        }
        [Fact]
        public void ActionMethod_Returns_String()
        {
            
            //Act
            //Run the get method on the controller
            var result = controller.Get();
            //Assert 
            //Check the get method returns something of type string
            Assert.IsType<ActionResult<String>>(result);
        }
        [Fact]
        public void PersonControllerGetURLMethod()
        {
            //Act
            var result = controller.GetURL("");
            //Assert
            Assert.IsType<ActionResult<string>>(result);
        }
    }
}
