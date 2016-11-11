using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using NewsApp.BLL.DTO;
using NewsApp.BLL.Interfaces;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class NewsController : Controller
    {
        private INewsService newsService;
        private IImageService imageService;

        public NewsController(INewsService newsService, IImageService imageService)
        {
            this.newsService = newsService;
            this.imageService = imageService;
        }

        [HttpGet]
        public ActionResult GetArticles(int id)
        {
            int numberOfArticles;
            int page = id;
            IEnumerable<ArticleDTO> articleDtos = newsService.GetArticles(page, out numberOfArticles);
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>());
            IEnumerable<ArticleViewModel> articleViews = Mapper.Map<IEnumerable<ArticleDTO>, IEnumerable<ArticleViewModel>>(articleDtos);
            var result = new
            {
                articles = articleViews,
                articlesNum = numberOfArticles,
                isAuthenticated = HttpContext.User.Identity.IsAuthenticated
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Article(int id)
        {
            ArticleDTO articleDto = newsService.GetArticle(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>());
            ArticleViewModel articleView = Mapper.Map<ArticleDTO, ArticleViewModel>(articleDto);
            return View("Article", articleView);
        }

        [HttpGet]
        public ActionResult Add()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View("~/Views/Account/NoPermission.cshtml");
            }
            return View("AddEdit");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View("~/Views/Account/NoPermission.cshtml");
            }
            ArticleDTO articleDto = newsService.GetArticle(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>());
            ArticleViewModel articleView = Mapper.Map<ArticleDTO, ArticleViewModel>(articleDto);
            return View("AddEdit", articleView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ArticleViewModel model)
        {
            if (ModelState.IsValid && (model.ImageName != null || model.Image != null))
            {
                model.ImageName = model.Image != null ? imageService.SaveImage(model.Image.InputStream, model.Image.FileName, Server.MapPath("~/Content/Images/")) : model.ImageName;
                Mapper.Initialize(cfg => cfg.CreateMap<ArticleViewModel, ArticleDTO>());
                ArticleDTO articleDto = Mapper.Map<ArticleViewModel, ArticleDTO>(model);
                if (model.Id == 0)
                {
                    newsService.CreateArticle(articleDto);
                }
                else
                {
                    newsService.UpdateArticle(articleDto);
                }
                return RedirectToAction("Index", "Home");
            }
            return View("AddEdit", model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View("~/Views/Account/NoPermission.cshtml");
            }
            newsService.DeleteArticle(id);
            return Json(id, JsonRequestBehavior.AllowGet);
        }
    }
}