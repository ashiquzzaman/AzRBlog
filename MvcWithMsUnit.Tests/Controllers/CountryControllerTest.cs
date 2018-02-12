using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcWithMsUnit.Controllers;
using MvcWithMsUnit.Entities;
using MvcWithMsUnit.Managers;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcWithMsUnit.Tests.Controllers
{
    [TestClass]
    public class CountryControllerTest
    {
        private Mock<ICountryManager> _countryManagerMock;
        CountryController objController;
        List<Country> listCountry;

        [TestInitialize]
        public void Initialize()
        {

            _countryManagerMock = new Mock<ICountryManager>();
            objController = new CountryController(_countryManagerMock.Object);
            listCountry = new List<Country>() {
           new Country() { Id = 1, Name = "US" },
           new Country() { Id = 2, Name = "India" },
           new Country() { Id = 3, Name = "Russia" }
          };
        }



        [TestMethod]
        public void Country_Get_All()
        {
            //Arrange
            _countryManagerMock.Setup(x => x.GetAll()).Returns(listCountry);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<Country>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);

        }

        [TestMethod]
        public void Valid_Country_Create()
        {
            //Arrange
            Country c = new Country() { Name = "test1" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(c);

            //Assert 
            _countryManagerMock.Verify(m => m.Create(c), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void Invalid_Country_Create()
        {
            // Arrange
            Country c = new Country() { Name = "" };
            objController.ModelState.AddModelError("Error", "Something went wrong");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _countryManagerMock.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }

    }
}
