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
        private CountryController _countryController;
        private List<Country> _list;

        [TestInitialize]
        public void Initialize()
        {
            _countryManagerMock = new Mock<ICountryManager>();
            _countryController = new CountryController(_countryManagerMock.Object);
            _list = new List<Country>
            {
                new Country { Id = 1, Name = "US" },
                new Country { Id = 2, Name = "India" },
                new Country { Id = 3, Name = "Russia" }
          };
        }


        [TestMethod]
        public void Index_WhenCalled_ReturnsListOfCountries()
        {
            //Arrange
            _countryManagerMock.Setup(x => x.GetAll()).Returns(_list);

            //Act
            var result = ((ViewResult)_countryController.Index()).Model as List<Country>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);

        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("@!&*")]
        public void Create_SaveWithEmptyOrInvalidCountryName_ReturnsValidationMessage(string countryName)
        {
            var country = new Country
            {
                Name = countryName
            };

            _countryController.ModelState.AddModelError("Error", @"Something went wrong");

            var result = (ViewResult)_countryController.Create(country);

            _countryManagerMock.Verify(m => m.Create(country), Times.Never);
            Assert.AreEqual("", result.ViewName);

        }


        [TestMethod]
        public void Create_SaveWithValidInput_ReturnsToIndexAction()
        {
            //Arrange
            var country = new Country { Name = "test1" };

            //Act
            var result = (RedirectToRouteResult)_countryController.Create(country);

            //Assert 
            _countryManagerMock.Verify(m => m.Create(country), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

    }
}
