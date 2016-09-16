using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NewsApp.BLL.DTO;
using NewsApp.BLL.Interfaces;
using NewsApp.DAL.Entities;
using NewsApp.DAL.Interfaces;

namespace NewsApp.BLL.Services
{
    public class NewsService : INewsService
    {
        public IUnitOfWork Database { get; set; }

        public NewsService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<ArticleDTO> GetArticles(int page, out int numberOfArticles)
        {
            IEnumerable<Article> articles = Database.Articles.GetItems(page, out numberOfArticles);
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDTO>());
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articles);
        }

        public ArticleDTO GetArticle(int id)
        {
            Article article = Database.Articles.GetItem(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDTO>());
            return Mapper.Map<Article, ArticleDTO>(article);
        }

        public void CreateArticle(ArticleDTO articleDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, Article>());
            Article article = Mapper.Map<ArticleDTO, Article>(articleDto);
            Database.Articles.Create(article);
        }

        public void UpdateArticle(ArticleDTO articleDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, Article>());
            Article article = Mapper.Map<ArticleDTO, Article>(articleDto);
            Database.Articles.Update(article);
        }

        public void DeleteArticle(int id)
        {
            Database.Articles.Delete(id);
        }
    }
}
