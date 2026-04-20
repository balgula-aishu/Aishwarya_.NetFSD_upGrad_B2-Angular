using NUnit.Framework;
using Moq;
using ContactManagement.Core;
using System.Collections.Generic;
using System;

namespace ContactManagement.Tests
{
    public class ContactServiceTests
    {
        private Mock<IContactRepository> _mockRepo;
        private IContactService _service;

        [SetUp]
        public void Setup()
        {
            _mockRepo = new Mock<IContactRepository>();
            _service = new ContactService(_mockRepo.Object);
        }

        // ✅ Test 1: AddContact Calls Repository
        [Test]
        public void AddContact_ShouldCallRepository()
        {
            // Arrange
            var contact = new Contact { Id = 1, Name = "Aishwarya", Email = "test@gmail.com" };

            // Act
            _service.AddContact(contact);

            // Assert (Verify interaction)
            _mockRepo.Verify(r => r.Add(contact), Times.Once);
        }

        // ✅ Test 2: GetContacts Returns Data
        [Test]
        public void GetContacts_ShouldReturnData()
        {
            // Arrange
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Test", Email = "test@gmail.com" }
            };

            _mockRepo.Setup(r => r.GetAll()).Returns(contacts);

            // Act
            var result = _service.GetContacts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        // ✅ Test 3: RemoveContact Returns True
        [Test]
        public void RemoveContact_ShouldReturnTrue()
        {
            // Arrange
            _mockRepo.Setup(r => r.Delete(1)).Returns(true);

            // Act
            var result = _service.RemoveContact(1);

            // Assert
            Assert.IsTrue(result);
        }

        // ✅ Test 4: AddContact Throws Exception
        [Test]
        public void AddContact_ShouldThrowException_WhenInvalid()
        {
            // Arrange
            var contact = new Contact { Id = 1, Name = "", Email = "test@gmail.com" };

            // Act & Assert
            Assert.Throws<Exception>(() => _service.AddContact(contact));
        }
    }
}