using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NewsApp.BLL.DTO;
using NewsApp.BLL.Interfaces;
using NewsApp.Controllers;
using NewsApp.Models;
using NUnit.Framework;

namespace NewsApp.Tests.ControllersTests
{
    [TestFixture]
    class AccountControllerTests
    {
        [Test]
        public void LoginViewResultIsNotNull()
        {
            var userService = new Mock<IUserService>();
            var controller = new AccountController(userService.Object);
            var result = controller.Login() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void LoginViewResultEqualsLoginCshtml()
        {
            var userService = new Mock<IUserService>();
            var controller = new AccountController(userService.Object);
            var result = controller.Login() as ViewResult;
            Assert.AreEqual("Login", result.ViewName);
        }
    }
}
