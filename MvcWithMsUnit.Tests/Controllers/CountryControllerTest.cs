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
        private List<Country> _countryList;

        [TestInitialize]
        public void Initialize()
        {
            _countryManagerMock = new Mock<ICountryManager>();
            _countryController = new CountryController(_countryManagerMock.Object);
            _countryList = new List<Country>
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
            _countryManagerMock.Setup(x => x.GetAll()).Returns(_countryList);

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
        [DataRow("ruxK8fqbr3bHGBmnbPzLdns2EDKRRRxAp0B7go6uIeWY8SD5cIKppgVIuOpSe1SpwYOH3d41vJ8GGb8XTqPCNjkuSXAgaKyobQmwl")]
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

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(4)]
        public void Edit_IdIsInvalid_ReturnsHttpNotFound(int id)
        {
            _countryManagerMock.Setup(c => c.GetById(id)).Returns(_countryList.Find(c => c.Id == id));

            var result = _countryController.Edit(id);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Edit_IdIsValid_ReturnsCountryWithProvidedId()
        {
            const int id = 1;

            _countryManagerMock.Setup(c => c.GetById(id)).Returns(_countryList[0]);

            var result = ((ViewResult)_countryController.Edit(id)).Model as Country;

            Assert.AreEqual(result, _countryList[0]);
        }

        [DataTestMethod]
        [DataRow("")]
        [DataRow("@!&*")]
        [DataRow("ruxK8fqbr3bHGBmnbPzLdns2EDKRRRxAp0B7go6uIeWY8SD5cIKppgVIuOpSe1SpwYOH3d41vJ8GGb8XTqPCNjkuSXAgaKyobQmwl")]
        public void Edit_SaveWithInvalidInput_ReturnsValidationMessage(string countryName)
        {
            var country = new Country
            {
                Name = countryName
            };

            _countryController.ModelState.AddModelError("Error", @"Something went wrong");

            var result = (ViewResult)_countryController.Edit(country);

            _countryManagerMock.Verify(m => m.Update(country), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void Edit_SaveWithValidInput_ReturnsToIndexAction()
        {
            var country = new Country { Name = "test1" };

            var result = (RedirectToRouteResult)_countryController.Edit(country);

            _countryManagerMock.Verify(m => m.Update(country), Times.Once);
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(4)]
        public void Delete_IdIsInvalid_ReturnsHttpNotFound(int id)
        {
            _countryManagerMock.Setup(c => c.GetById(id)).Returns(_countryList.Find(c => c.Id == id));

            var result = _countryController.Delete(id);

            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Delete_IdIsValid_ReturnsCountryWithProvidedId()
        {
            const int id = 1;

            _countryManagerMock.Setup(c => c.GetById(id)).Returns(_countryList[0]);

            var result = ((ViewResult)_countryController.Delete(id)).Model as Country;

            Assert.AreEqual(result, _countryList[0]);
        }
    }
}
