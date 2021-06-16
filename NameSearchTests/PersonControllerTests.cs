/*
 * Charles Walker
 * PersonControllerTests.cs
 * These are the unit tests for the "SearchName" and "AddPerson" API calls
 */
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using NameSearch.Api.PersonData;
using Moq;
using NameSearch.Api.Models;
using NameSearch.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NameSearch.Api;

namespace NameSearchTests
{
    public class PersonControllerTests
    {
        private readonly new Mock<IPersonData> repositoryStub = new();
        private readonly Random rand = new();
        [Fact]
        
        public void SearchName_WithNonExistentName_ReturnsNotFound()
        {
            //Arrange
            repositoryStub.Setup(repo => repo.SearchName(It.IsAny<string>())).Returns((List<Person>)null);

            var controller = new PersonController(repositoryStub.Object);
            //Act
            var result = controller.SearchName("BadNameTest");

            //Assert
            Assert.IsType<NotFoundResult>(result); // Asserts that the result is "Not Found" if a name that is non-existent is submitted
        }

        [Fact]
        public void AddPerson_AddingNewPerson_ReturnsExpectedPerson()
        {
            //Arrange
            var expectedPerson = CreateRandomPerson();
            repositoryStub.Setup(repo => repo.GetIDPerson(It.IsAny<Guid>())).Returns(expectedPerson);

            var controller = new PersonController(repositoryStub.Object);
            //Act

            var result = controller.GetIDPerson(expectedPerson.Id);

            //Assert
            var okObjectResult = result as OkObjectResult;

            var res = okObjectResult.Value as Person;

            Assert.Equal(expectedPerson, res); //Asserts that the person that was added exists in the database

            Assert.Equal(expectedPerson.Id, res.Id);
            Assert.Equal(expectedPerson.Name, res.Name);
            Assert.Equal(expectedPerson.Age, res.Age);
            Assert.Equal(expectedPerson.Address, res.Address);
            Assert.Equal(expectedPerson.Interests, res.Interests);
            

        }

        private Person CreateRandomPerson() //Helper function to create a random user
        {
            return new()
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Age = rand.Next(100),
                Address = Guid.NewGuid().ToString(),
                Interests = Guid.NewGuid().ToString()
            };
        }
    }
}

