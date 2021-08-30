using ApplicationShared.Activities.Commands;
using AutoMapper;
using Domain;
using Factories.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FactoriesTest.Activities
{
    [TestClass]
    public class TestAcitivityFactory
    {
        private Mock<IMapper> _mockMapper;

        private ActivityFactory _sut;

        [TestInitialize]
        public void Init()
        {
            _mockMapper = new Mock<IMapper>();

            _sut = new ActivityFactory(_mockMapper.Object);
        }

        [TestMethod]
        public void UpdateActivity_ShouldThrowNullReferenceException_WhenEditActivityCommandIsNull()
        {
            // Arrange
            Activity activity = new();
            EditActivityCommand command = null;

            // Act
            // Assert
            NullReferenceException result = Assert.ThrowsException<NullReferenceException>(() => _sut.UpdateActivity(activity, command));

            Assert.AreEqual("EditActivityCommand is null", result.Message);
        }

        [TestMethod]
        public void UpdateActivity_ShouldUpdateActivityWithProperties_WhenEditActivityCommandIsNotNull()
        {
            // Arrange
            string city = "Calgary";
            string venue = "CrossIron Mall";
            string title = "EditActivityCommand";
            string description = "Command to edit activity";
            DateTime dateTime = DateTime.Now;
            Activity activity = new();
            EditActivityCommand command = new(new Guid(),
                                              title,
                                              description,
                                              dateTime,
                                              city,
                                              venue);

            // Act
            Activity result = _sut.UpdateActivity(activity, command);

            // Assert
            Assert.AreEqual(city, result.City);
            Assert.AreEqual(title, result.Title);
            Assert.AreEqual(venue, result.Venue);
            Assert.AreEqual(dateTime, result.OnDate);
            Assert.AreEqual(description, result.Description);
        }
    }
}
