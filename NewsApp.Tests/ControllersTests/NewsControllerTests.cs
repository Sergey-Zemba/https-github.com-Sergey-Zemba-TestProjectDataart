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
        #region GetArticles Tests
        [Test]
        public void ReturnedJsonByGetArticlesIsNotNullAndCorrect()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            int numberOfArticles = 10;
            httpContext.Setup(t => t.User).Returns(principal);
            newsService.Setup(x => x.GetArticles(It.IsInRange(1, int.MaxValue, Range.Inclusive), out numberOfArticles))
                .Returns(new List<ArticleDTO> { new ArticleDTO() });
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.GetArticles(rand.Next(1, int.MaxValue)) as JsonResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, (result.Data.GetType().GetProperty("articles").GetValue(result.Data) as List<ArticleViewModel>).Count);
            Assert.AreEqual(numberOfArticles, result.Data.GetType().GetProperty("articlesNum").GetValue(result.Data));
            Assert.AreEqual(false, result.Data.GetType().GetProperty("isAuthenticated").GetValue(result.Data));
        }
        #endregion

        #region Article Tests
        [Test]
        public void ArticleViewResultIsNotNull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var controller = new NewsController(newsService.Object, imageService.Object);
            Random rand = new Random();
            var result = controller.Article(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void ArticleViewResultEqualsArticleCshtml()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var controller = new NewsController(newsService.Object, imageService.Object);
            Random rand = new Random();
            var result = controller.Article(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.AreEqual("Article", result.ViewName);
        }

        [Test]
        public void ArticleViewModelIsNotNull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            newsService.Setup(x => x.GetArticle(It.IsInRange(1, int.MaxValue, Range.Inclusive)))
                .Returns(new ArticleDTO());
            var controller = new NewsController(newsService.Object, imageService.Object);
            Random rand = new Random();
            var result = controller.Article(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void ArticleViewModelIsCorrect()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            newsService.Setup(x => x.GetArticle(It.IsInRange(1, int.MaxValue, Range.Inclusive)))
                .Returns(new ArticleDTO
                {
                    Id = 1,
                    Content = "some content",
                    CreationDate = "04.10.2016 11:59:25",
                    ImageName = "some image",
                    ShortDescription = "some description",
                    Title = "some title"
                });
            var controller = new NewsController(newsService.Object, imageService.Object);
            Random rand = new Random();
            var result = controller.Article(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.AreEqual(1, (result.Model as ArticleViewModel).Id);
            Assert.AreEqual("some content", (result.Model as ArticleViewModel).Content);
            Assert.AreEqual("04.10.2016 11:59:25", (result.Model as ArticleViewModel).CreationDate);
            Assert.AreEqual("some image", (result.Model as ArticleViewModel).ImageName);
            Assert.AreEqual("some description", (result.Model as ArticleViewModel).ShortDescription);
            Assert.AreEqual("some title", (result.Model as ArticleViewModel).Title);
        }
        #endregion

        #region Add Tests
        [Test]
        public void AddViewResultIsNotNull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            var result = controller.Add() as ViewResult;
            Assert.IsNotNull(result);
            principal = new GenericPrincipal(new GenericIdentity("User"), null);
            httpContext.Setup(t => t.User).Returns(principal);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            result = controller.Add() as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void IsAllowedToAddIfUserIsAuthenticated()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("AddEdit", result.ViewName);
        }

        [Test]
        public void IsNotAllowedToAddIfUserIsNotAuthenticated()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            var result = controller.Add() as ViewResult;
            Assert.AreEqual("~/Views/Account/NoPermission.cshtml", result.ViewName);
        }
        #endregion

        #region Edit Tests
        [Test]
        public void EditViewResultIsNotNull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.Edit(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.IsNotNull(result);
            principal = new GenericPrincipal(new GenericIdentity("User"), null);
            httpContext.Setup(t => t.User).Returns(principal);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            result = controller.Edit(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void IsAllowedToEditIfUserIsAuthenticated()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.Edit(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.AreEqual("AddEdit", result.ViewName);
        }

        [Test]
        public void IsNotAllowedToEditIfUserIsNotAuthenticated()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.Edit(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.AreEqual("~/Views/Account/NoPermission.cshtml", result.ViewName);
        }

        [Test]
        public void EditArticleViewModelIsNotNull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            newsService.Setup(x => x.GetArticle(It.IsInRange(1, int.MaxValue, Range.Inclusive)))
                .Returns(new ArticleDTO());
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.Edit(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void EditArticleViewModelIsCorrect()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            newsService.Setup(x => x.GetArticle(It.IsInRange(1, int.MaxValue, Range.Inclusive)))
                .Returns(new ArticleDTO
                {
                    Id = 1,
                    Content = "some content",
                    CreationDate = "04.10.2016 11:59:25",
                    ImageName = "some image",
                    ShortDescription = "some description",
                    Title = "some title"
                });
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.Edit(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.AreEqual(1, (result.Model as ArticleViewModel).Id);
            Assert.AreEqual("some content", (result.Model as ArticleViewModel).Content);
            Assert.AreEqual("04.10.2016 11:59:25", (result.Model as ArticleViewModel).CreationDate);
            Assert.AreEqual("some image", (result.Model as ArticleViewModel).ImageName);
            Assert.AreEqual("some description", (result.Model as ArticleViewModel).ShortDescription);
            Assert.AreEqual("some title", (result.Model as ArticleViewModel).Title);
        }
        #endregion

        #region Save Tests

        [Test]
        public void SaveViewResultIsNotNullIfModelIsNotFull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var controller = new NewsController(newsService.Object, imageService.Object);
            var result = controller.Save(new ArticleViewModel
            {
                Content = "some content",
                ShortDescription = "some description",
                Title = "some title"
            }) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void SaveViewResultEqualsAddEditCshtmlIfModelIsNotFull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var controller = new NewsController(newsService.Object, imageService.Object);
            var result = controller.Save(new ArticleViewModel
            {
                Content = "some content",
                ShortDescription = "some description",
                Title = "some title"
            }) as ViewResult;
            Assert.AreEqual("AddEdit", result.ViewName);
        }

        [Test]
        public void SaveArticleViewModelIsNotNullIfModelIsNotFull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var controller = new NewsController(newsService.Object, imageService.Object);
            var result = controller.Save(new ArticleViewModel
            {
                Content = "some content",
                ShortDescription = "some description",
                Title = "some title"
            }) as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [Test]
        public void SaveArticleViewModelIsCorrectIfModelIsNotFull()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var controller = new NewsController(newsService.Object, imageService.Object);
            var result = controller.Save(new ArticleViewModel
            {
                Content = "some content",
                ShortDescription = "some description",
                Title = "some title"
            }) as ViewResult;
            Assert.AreEqual("some content", (result.Model as ArticleViewModel).Content);
            Assert.AreEqual("some description", (result.Model as ArticleViewModel).ShortDescription);
            Assert.AreEqual("some title", (result.Model as ArticleViewModel).Title);
        }

        [Test]
        public void SaveShouldRedirectToHomePageIfModeWasAcceptedAndSaved()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var controller = new NewsController(newsService.Object, imageService.Object);
            var result = controller.Save(new ArticleViewModel
            {
                Content = "some content",
                ImageName = "some image",
                ShortDescription = "some description",
                Title = "some title"
            }) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("Home", result.RouteValues["controller"]);
        }
        #endregion

        #region Delete Tests

        [Test]
        public void DeleteViewResultIsNotNullIfUserIsNotAuthenticated()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.Delete(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.IsNotNull(result);
        }

        [Test]
        public void IsNotAllowedToDeleteIfUserIsNotAuthenticated()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity(String.Empty), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            var result = controller.Delete(rand.Next(1, int.MaxValue)) as ViewResult;
            Assert.AreEqual("~/Views/Account/NoPermission.cshtml", result.ViewName);
        }

        [Test]
        public void ReturnedJsonByDeleteIsNotNullAndCorrectIfUserIsAuthenticated()
        {
            var newsService = new Mock<INewsService>();
            var imageService = new Mock<IImageService>();
            var httpContext = new Mock<HttpContextBase>();
            var principal = new GenericPrincipal(new GenericIdentity("User"), null);
            httpContext.Setup(t => t.User).Returns(principal);
            var controller = new NewsController(newsService.Object, imageService.Object);
            controller.ControllerContext = new ControllerContext(httpContext.Object, new RouteData(), controller);
            Random rand = new Random();
            int randomId = rand.Next(1, int.MaxValue);
            var result = controller.Delete(randomId) as JsonResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(randomId, result.Data);
        }
        #endregion

    }
}
