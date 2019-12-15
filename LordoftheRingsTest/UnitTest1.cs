using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using LordoftheRings;
using LordoftheRings.Models;
using LordoftheRings.Controllers;

namespace LordoftheRingsTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddMethodWithTwoPositiveNumbers()
        {
            //Arrange - instan. classes etc.
            var testService = new TestService();

            //Act - Call the method to test
            int result = testService.Add(2, 5);

            //Assert - Check if you get the right result back
            Assert.Equal(7, result);
        }

        [Fact]
        public void TestIndexMethodReturnsObjects()
        {
            // Arrange
            var mockRepo = new Mock<IRaceRepository>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(DataTestService.GetTestRace());
            var controller = new RaceController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Race>>(
                viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void CreatePost_ReturnsViewWithRace_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IRaceRepository>();
            var controller = new RaceController(mockRepo.Object);

            controller.ModelState.AddModelError("Name", "Required");
            var race = new Race() { Name = "", Description = "Karl Karlson something nice" };

            // Act
            var result = controller.Create(race);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Race>(viewResult.ViewData.Model);
            Assert.IsType<Race>(model);
        }

        [Fact]
        public void CreatePost_SaveThroughRepository_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IRaceRepository>();
            mockRepo.Setup(repo => repo.Save(It.IsAny<Race>()))
                //.Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new RaceController(mockRepo.Object);
            Race r = new Race()
            {
                Name = "Human",
                Description = "Don't listen to scientists"
            };

            // Act
            var result = controller.Create(r);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }
        [Fact]
        public void TestHookupIndex()
        {

            // Arrange
            var mockRepo = new Mock<ICatDateRepository>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(TestService.GetCatDates());
            var controller = new CatDateController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Hookup>>(
                viewResult.ViewData.Model);
            Assert.Equal(1, model.Count());
        }
    }
}
