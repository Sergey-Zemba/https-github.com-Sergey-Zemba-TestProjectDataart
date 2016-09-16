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

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
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
                articlesNum = numberOfArticles
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Article(int id)
        {
            ArticleDTO articleDto = newsService.GetArticle(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>());
            ArticleViewModel articleView = Mapper.Map<ArticleDTO, ArticleViewModel>(articleDto);
            return View(articleView);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ArticleViewModel, ArticleDTO>());
                ArticleDTO articleDto = Mapper.Map<ArticleViewModel, ArticleDTO>(model);
                newsService.CreateArticle(articleDto);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ArticleDTO articleDto = newsService.GetArticle(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, ArticleViewModel>());
            ArticleViewModel articleView = Mapper.Map<ArticleDTO, ArticleViewModel>(articleDto);
            return View(articleView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleViewModel model)
        {
            if (ModelState.IsValid)
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ArticleViewModel, ArticleDTO>());
                ArticleDTO articleDto = Mapper.Map<ArticleViewModel, ArticleDTO>(model);
                newsService.UpdateArticle(articleDto);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public void Delete(int id)
        {
            newsService.DeleteArticle(id);
        }
    }
}