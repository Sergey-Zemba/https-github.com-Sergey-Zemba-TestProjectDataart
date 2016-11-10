using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewsApp.Controllers;

namespace NewsApp.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
