using service_one.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Project_2.Tests
{
    public class PersonControllerTests
    {
        [Fact]
        public async Task ActionMethod_Returns_String()
        {
            //Arrange
            //Create local controller to test
            var controller = new PersonController();
            //Act
            //Run the get method on the controller
            var result = controller.Get();
            //Assert 
            //Check the get method returns something of type string
            Assert.IsType<String>(result);
        }
    }
}
