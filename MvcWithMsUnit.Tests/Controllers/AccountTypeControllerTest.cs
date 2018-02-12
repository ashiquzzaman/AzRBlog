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
    public class AccountTypeControllerTest
    {
        private Mock<IAccountTypeManager> _accountTypeManagerMock;
        AccountTypeController objController;
        List<AccountType> list;

        [TestInitialize]
        public void Initialize()
        {

            _accountTypeManagerMock = new Mock<IAccountTypeManager>();
            objController = new AccountTypeController(_accountTypeManagerMock.Object);
            list = new List<AccountType> {
                new AccountType { Id = 1, Name = "SAVING" },
                new AccountType { Id = 2, Name = "CURRENT" },
                new AccountType { Id = 3, Name = "LOAN" }
            };
        }
        [TestMethod]
        public void Index_WhenCalled_RetunsAccountTypeList()
        {
            //Arrange
            _accountTypeManagerMock.Setup(x => x.GetAll()).Returns(list);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<AccountType>;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("SAVING", result[0].Name);
            //Assert.AreEqual("India", result[1].Name);
            //Assert.AreEqual("Russia", result[2].Name);

        }
    }
}
