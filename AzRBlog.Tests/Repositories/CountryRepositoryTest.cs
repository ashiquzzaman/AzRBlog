using AzRBlog.Entities;
using AzRBlog.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AzRBlog.Tests.Repositories
{
    [TestClass]
    public class CountryRepositoryTest
    {

        TestContext databaseContext;
        CountryRepository objRepo;

        [TestInitialize]
        public void Initialize()
        {

            databaseContext = new TestContext();
            objRepo = new CountryRepository(databaseContext);

        }

        [TestMethod]
        public void Country_Repository_Get_ALL()
        {
            //Act
            var result = objRepo.GetAll().ToList();

            //Assert

            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("US", result[0].Name);
            Assert.AreEqual("India", result[1].Name);
            Assert.AreEqual("Russia", result[2].Name);
        }

        [TestMethod]
        public void Country_Repository_Create()
        {
            //Arrange
            Country c = new Country { Name = "UK" };

            //Act
            var result = objRepo.Add(c);
            databaseContext.SaveChanges();

            var lst = objRepo.GetAll().ToList();

            //Assert

            Assert.AreEqual(4, lst.Count);
            Assert.AreEqual("UK", lst.Last().Name);
        }
    }
}
