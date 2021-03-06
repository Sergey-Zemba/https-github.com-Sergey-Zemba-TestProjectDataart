﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;
using NewsApp.Models;
using NUnit.Framework;

namespace NewsApp.Tests.ModelsTests
{
    [TestFixture]
    class ArticleViewModelTests
    {
        [Test]
        public void ShouldNotSaveArticleIfImageIsNotAttached()
        {
            var articleViewModel = new ArticleViewModel();
            var validationResult = articleViewModel.Validate(new ValidationContext(new object()));
            Assert.IsNotEmpty(validationResult);
            Assert.AreEqual("You have to attach an image", validationResult.First().ErrorMessage);
        }

        [Test]
        public void ShouldSaveArticleIfImageNameIsSpecified()
        {
            var articleViewModel = new ArticleViewModel
            {
                ImageName = String.Empty
            };
            var validationResult = articleViewModel.Validate(new ValidationContext(new object()));
            Assert.IsEmpty(validationResult);
        }

        [Test]
        public void ShouldSaveArticleIfImageIsAttached()
        {
            var articleViewModel = new ArticleViewModel
            {
                Image = new Mock<HttpPostedFileBase>().Object
            };
            var validationResult = articleViewModel.Validate(new ValidationContext(new object()));
            Assert.IsEmpty(validationResult);
        }
    }
}
