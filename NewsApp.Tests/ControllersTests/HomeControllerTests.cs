using System;
using System.Web.Mvc;
using NewsApp.Controllers;
using NUnit.Framework;

namespace NewsApp.Tests.ControllersTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController controller;
        private ViewResult result;

        [OneTimeSetUp]
        public void SetupContext()
        {
            controller = new HomeController();
            result = controller.Index() as ViewResult;
        }
        [Test]
        public void IndexViewResultIsNotNull()
        {
            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewEqualsIndexCshtml()
        {
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
