using Frontend.Controllers;
using Frontend.Interfaces;
using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project_2.Tests
{
    public class WeddingsControllerTest
    {
        private WeddingsController weddingsController;
        private Mock<IRepoWrapper> mockRepo;

        //Using the repo pattern and moq testing, we can create a fake database so that the testing of the weddings controller 
        //doesn't require using the actual database.
        public WeddingsControllerTest()
        {
            //weddingMock = new Mock<IWedding>();
            //weddingsMock = new List<IWedding> { weddingMock.Object };

            mockRepo = new Mock<IRepoWrapper>();
            weddingsController = new WeddingsController(mockRepo.Object);
        }

        //Arrange
        //GetWeddings: A method that returns fake data entries to use when testing the controller
        private IEnumerable<Wedding> GetWeddings()
        {
            return new List<Wedding>()
            {
                new Wedding{ID=1,WeddingText="",PersonURL="",PlaceURL="",Date=DateTime.Now},
                new Wedding{ID=1,WeddingText="",PersonURL="",PlaceURL="",Date=DateTime.Now}
            };
        }

        [Fact]
        public void TestWeddingsControllerIndexMethod()
        {
            //This line sets up the Weddings.FindAll() function to return the same thing as GetWeddings above
            mockRepo.Setup(repo => repo.Weddings.FindAll()).Returns(GetWeddings());

            //Act
            //Store the result of the Mocked wedding controller's index method which should call the FindAll method
            var result = weddingsController.Index();

            //Assert the controller returns the correct type of object (a view result)
            Assert.IsType<ViewResult>(result);
        }
        
    }
}
