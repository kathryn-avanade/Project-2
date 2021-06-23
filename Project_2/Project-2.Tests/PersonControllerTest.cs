using Microsoft.AspNetCore.Mvc;
using service_one.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Project_2.Tests
{
    public class PersonControllerTest
    {
        //Arrange
        //Create local controller to test

        private PersonController controller;
        public PersonControllerTest()
        {
            controller = new PersonController();
        }
        
        [Fact]
        public void PersonControllerGetMethod()
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
            var result = controller.GetURL("");
            Assert.IsType<ActionResult<string>>(result);
        }
    }
}
