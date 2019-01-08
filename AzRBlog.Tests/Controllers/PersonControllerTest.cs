using AzRBlog.Entities;
using AzRBlog.Services;
using AzRBlog.Web.Areas.Admin.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AzRBlog.Tests.Controllers
{
    [TestClass]

    public class PersonControllerTest
    {
        private Mock<ICountryService> _countryManagerMock;
        private Mock<IUserProfileService> _personManagerMock;
        UserController objController;
        List<UserProfile> list;

        [TestInitialize]
        public void Initialize()
        {

            _countryManagerMock = new Mock<ICountryService>();
            _personManagerMock = new Mock<IUserProfileService>();
            objController = new UserController(_personManagerMock.Object, _countryManagerMock.Object);
            list = new List<UserProfile>() {
                new UserProfile { Id = 1, Name = "Ashiq",Mobile="000001",Address="Dhaka",State="Shyamoli",CountryId=1},
                new UserProfile { Id = 2, Name = "Rajib",Mobile="000002",Address="Khulna",State="Rupsha",CountryId=1},
                new UserProfile { Id = 3, Name = "Zaman",Mobile="000003",Address="Jessore",State="N.para",CountryId=1}
            };
        }
        [TestMethod]
        public void Person_Get_All()
        {
            //Arrange
            _personManagerMock.Setup(x => x.GetAll()).Returns(list);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<UserProfile>;

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
