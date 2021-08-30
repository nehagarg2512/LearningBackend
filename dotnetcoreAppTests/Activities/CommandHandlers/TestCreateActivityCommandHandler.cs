using Application.Activities.CommandHandlers;
using ApplicationShared.Activities.Commands;
using Common.Errors;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Persistence.Repositories;
using Persistence.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationTests.Activities.CommandHandlers
{
    [TestClass]
    public class TestCreateActivityCommandHandler
    {
        private Mock<IPersistenceUnitOfWork> _mockPersistenceUnitOfWork;

        private CreateActivityCommandHandler _sut;

        [TestInitialize]
        public void Init()
        {
            Mock<IRepository<Activity>> mockRepository = new Mock<IRepository<Activity>>();
            mockRepository
                .Setup(x => x.Add(It.IsAny<Activity>()))
                .Returns(new Activity());

            _mockPersistenceUnitOfWork = new Mock<IPersistenceUnitOfWork>();
            _mockPersistenceUnitOfWork
                .Setup(x => x.GetGenericRepository<Activity>())
                .Returns(mockRepository.Object);

            _sut = new CreateActivityCommandHandler(_mockPersistenceUnitOfWork.Object);
        }

        [TestMethod]
        public async Task Handle_Should_ThrowsActivityNotSavedException_When_CreateActivityCommandIsNull()
        {
            // Arrange
            CreateActivityCommand command = null;

            // Act
            // Assert
            ActivityNotSavedException actualException = 
                await Assert.ThrowsExceptionAsync<ActivityNotSavedException>(async () => await _sut.Handle(command, CancellationToken.None));

            Assert.AreEqual("Create activity command is null.", actualException.Message);
            _mockPersistenceUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [TestMethod]
        public async Task Handle_Should_CallSaveChangesAsyncOnce_When_CreateActivityCommandIsNotNull()
        {
            // Arrange
            CreateActivityCommand command = new CreateActivityCommand(new Guid(), "Test CreateActivity Title", 
                "Test description", DateTime.Now, "London", "Pub");

            // Act
            await _sut.Handle(command, CancellationToken.None);

            // Assert
            _mockPersistenceUnitOfWork.Verify(x => x.SaveChangesAsync(), Times.Once);
        }
    }
}