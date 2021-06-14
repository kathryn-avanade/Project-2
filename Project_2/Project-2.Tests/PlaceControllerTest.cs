using Microsoft.AspNetCore.Mvc;
using service_two.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Project_2.Tests
{
    public class PlaceControllerTest
    {
        [Fact]
        public void ActionMethod_Returns_String()
        {
            //Arrange
            //Create local controller to test
            var controller = new PlaceController();
            //Act
            //Run the get method on the controller
            var result = controller.Get();
            //Assert 
            //Check the get method returns something of type string
            Assert.IsType<ActionResult<String>>(result);
        }
    }
}
