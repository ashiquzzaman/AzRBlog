﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AzRBlog.Entities;
using AzRBlog.Services;
using AzRBlog.Repositories;
using System.Collections.Generic;

namespace AzRBlog.Tests.Managers
{
    [TestClass]
    public class CountryManagerTest
    {
        private Mock<ICountryRepository> _mockRepository;
        private ICountryManager _service;
        List<Country> list;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<ICountryRepository>();
            _service = new CountryManager(_mockRepository.Object);
            list = new List<Country> {
                new Country { Id = 1, Name = "US" },
                new Country { Id = 2, Name = "India" },
                new Country { Id = 3, Name = "Russia" }
            };
        }

        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(list);

            //Act
            var results = _service.GetAll() as List<Country>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }


        [TestMethod]
        public void Can_Add_Country()
        {
            //Arrange
            var Id = 1;
            var emp = new Country { Name = "UK" };
            _mockRepository.Setup(m => m.Add(emp)).Returns((Country e) =>
            {
                e.Id = Id;
                return e;
            });

            //Act
            _service.Create(emp);

            //Assert
            Assert.AreEqual(Id, emp.Id);
            _mockRepository.Verify(m => m.Save(), Times.Once);
        }

    }
}
