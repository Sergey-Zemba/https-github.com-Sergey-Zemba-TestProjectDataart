using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using NewsApp.BLL.DTO;
using NewsApp.BLL.Interfaces;
using NewsApp.Controllers;
using NewsApp.Models;
using NUnit.Framework;

namespace NewsApp.Tests.ControllersTests
{
    [TestFixture]
    class NewsControllerTests
    {
        [Test]
        public void CheckReturnedJsonByGetArticles()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpRequest = new Mock<HttpRequestBase>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            int numberOfArticles = 10;
            httpContext.Setup(t => t.User).Returns(principal);
            httpContext.Setup(c => c.Request).Returns(httpRequest.Object);
            newsService.Setup(x => x.GetArticles(It.IsInRange(1, int.MaxValue, Range.Inclusive), out numberOfArticles))
                .Returns(new List<ArticleDTO> {new ArticleDTO()});
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.GetArticles(rand.Next(1, int.MaxValue)) as JsonResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, (result.Data.GetType().GetProperty("articles").GetValue(result.Data) as List<ArticleViewModel>).Count);
            Assert.AreEqual(numberOfArticles, result.Data.GetType().GetProperty("articlesNum").GetValue(result.Data));
            Assert.AreEqual(false, result.Data.GetType().GetProperty("isAuthenticated").GetValue(result.Data));
        }
    }
}
