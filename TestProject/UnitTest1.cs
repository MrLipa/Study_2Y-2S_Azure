using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Controllers;
using Project.Interfaces;
using Project.Models;
using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TestProject
{
    [TestClass]
    public class AppUserControllerTests
    {
        private Mock<IAppUserRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private AppUserController _controller;

        [TestInitialize]
        public void Setup()
        {
            // Mock the IAppUserRepository
            _mockRepository = new Mock<IAppUserRepository>();

            // Mock the IMapper
            _mockMapper = new Mock<IMapper>();

            // Initialize the controller with the mocked objects
            _controller = new AppUserController(_mockRepository.Object, _mockMapper.Object);
        }

        [TestMethod]
        public void CreateAppUser_ShouldReturnCreatedAtActionResult_WhenDataIsValid()
        {
            // Arrange
            var newUser = new AppUser { /* set properties as needed */ };
            var mappedUser = new AppUser { /* set properties as expected after mapping */ };
            _mockMapper.Setup(m => m.Map<AppUser>(It.IsAny<AppUser>())).Returns(mappedUser);
            _mockRepository.Setup(r => r.AddAppUser(It.IsAny<AppUser>()));

            // Act
            var result = _controller.CreateAppUser(newUser);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedAtActionResult));
            _mockRepository.Verify(r => r.AddAppUser(It.IsAny<AppUser>()), Times.Once);
        }
    }
}
