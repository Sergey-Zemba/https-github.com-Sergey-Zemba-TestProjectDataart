using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class ArticleController : Controller
    {
        private ArticleManager manager;

        public ArticleController()
        {
            manager = new ArticleManager();
        }

        [HttpGet]
        public ActionResult GetArticles(int id)
        {
            int numberOfPages;
            int page = id;

            var result = new
            {
                articles = manager.GetArticles(page, out numberOfPages),
                pages = numberOfPages
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetArticle(int id)
        {
            return View(manager.GetArticle(id));
        }
    }
}