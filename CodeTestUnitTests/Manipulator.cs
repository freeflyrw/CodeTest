using NUnit.Framework;
using Microsoft.Extensions.Logging;
using CodeTest.Controllers;
using Moq;
using CodeTest;
using Microsoft.AspNetCore.Mvc;

namespace CodeTestUnitTests
{
    [TestFixture]
    public class Manipulator
    {
        private ManipulatorController _controller;
        private  Mock<ILogger<ManipulatorController>> _mockLogger;
        
        public Manipulator()
        {
            _mockLogger = new Mock<ILogger<ManipulatorController>>();
            _controller = new ManipulatorController(_mockLogger.Object);
        }

      
        [Test]
        [TestCase("Hello")]
        [TestCase("Test")]
        public void WhenPassedAStringShouldReturnReversedString(string stringToTest)
        {
            var response = _controller.ReverseMessage(stringToTest);

            Assert.AreEqual(stringToTest.ReverseString(),response.GetValueFromResult());
        }

        [Test]
        public void WhenStringLessThanEqual1024CharsReturnsStringType()
        {
            var response = _controller.ReverseMessage(new string('*', 1024));

            Assert.IsInstanceOf<OkObjectResult>(response.Result);
            Assert.That(response.GetValueFromResult(), Is.TypeOf<string>());
        }

        [Test]
        public void WhenStringMoreThan1024CharsReturnBadRequest()
        {
            Assert.IsInstanceOf<BadRequestObjectResult>(_controller.ReverseMessage(new string('*', 1025)).Result);
        }

        [Test]
        public void WhenNullStringReturnBadRequest()
        {
            var response = _controller.ReverseMessage(null);
            Assert.IsInstanceOf<BadRequestObjectResult>(response.Result);
        }

        [Test]
        public void WhenEmptyStringReturnBadRequest()
        {
            var response = _controller.ReverseMessage(string.Empty);
            Assert.IsInstanceOf<BadRequestObjectResult>(response.Result);
        }

        [Test]        
        public void WhenPostStringLessThan1024CharsReturnsStringType()
        {
            var response = _controller.ReverseMessageBody(new ManipulatorModel() { Message = new string('*', 1024) });

            Assert.IsInstanceOf<OkObjectResult>(response.Result);

            Assert.That(response.GetValueFromResult().Message, Is.TypeOf<string>());
        }

        [Test]
        public void WhenPostStringGreaterThan1024CharsReturnsStringType()
        {
            var response = _controller.ReverseMessageBody(new ManipulatorModel() { Message = new string('*', 3000) });

            Assert.IsInstanceOf<OkObjectResult>(response.Result);

            Assert.That(response.GetValueFromResult().Message, Is.TypeOf<string>());
        }
    }
}