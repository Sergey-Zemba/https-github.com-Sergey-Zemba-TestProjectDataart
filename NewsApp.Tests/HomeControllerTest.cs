using System;
using System.Web.Mvc;
using NewsApp.Controllers;
using NUnit.Framework;

namespace NewsApp.Tests
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void TestMethod1()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
