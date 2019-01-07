using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AzRBlog.Entities;
using AzRBlog.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using AzRBlog.Web.Controllers;

namespace AzRBlog.Tests.Controllers
{
    [TestClass]

    public class PersonControllerTest
    {
        private Mock<ICountryManager> _countryManagerMock;
        private Mock<IPersonManager> _personManagerMock;
        PersonController objController;
        List<Person> list;

        [TestInitialize]
        public void Initialize()
        {

            _countryManagerMock = new Mock<ICountryManager>();
            _personManagerMock = new Mock<IPersonManager>();
            objController = new PersonController(_personManagerMock.Object, _countryManagerMock.Object);
            list = new List<Person>() {
                new Person { Id = 1, Name = "Ashiq",Phone="000001",Address="Dhaka",State="Shyamoli",CountryId=1},
                new Person { Id = 2, Name = "Rajib",Phone="000002",Address="Khulna",State="Rupsha",CountryId=1},
                new Person { Id = 3, Name = "Zaman",Phone="000003",Address="Jessore",State="N.para",CountryId=1}
            };
        }
        [TestMethod]
        public void Person_Get_All()
        {
            //Arrange
            _personManagerMock.Setup(x => x.GetAll()).Returns(list);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<Person>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("Ashiq", result[0].Name);
            Assert.AreEqual("Rajib", result[1].Name);
            Assert.AreEqual("Zaman", result[2].Name);

        }
        public void Person_Get_Country_DropDown()
        {
            // Arrange


            // Act
            ViewResult result = objController.Create() as ViewResult;

            // Assert
            //  Assert.AreEqual(null, result.ViewBag.CountryId);
            Assert.IsNull(result.ViewBag.CountryId);

        }
    }
}
