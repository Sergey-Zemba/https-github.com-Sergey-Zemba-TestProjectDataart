using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using NewsApp.BLL.DTO;
using NewsApp.BLL.ServiceReference1;
using NewsApp.DAL.Interfaces;
using INewsService = NewsApp.BLL.Interfaces.INewsService;

namespace NewsApp.BLL.Services
{
    public class NewsService : INewsService
    {
        private NewsServiceClient client;
        public NewsService()
        {
            client = new NewsServiceClient();
        }
        public IEnumerable<ArticleDTO> GetArticles(int page, out int numberOfArticles)
        {
            IEnumerable<Article> articlesFromSevice = client.GetArticles(page, out numberOfArticles).ToList();
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDTO>());
            return Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleDTO>>(articlesFromSevice);
        }

        public ArticleDTO GetArticle(int id)
        {
            Article articleFromService = client.GetArticle(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDTO>());
            return Mapper.Map<Article, ArticleDTO>(articleFromService);
        }

        public ArticleDTO CreateArticle(ArticleDTO articleDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, Article>());
            Article articleForService = Mapper.Map<ArticleDTO, Article>(articleDto);
            Article articleFromService = client.CreateArticle(articleForService);
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDTO>());
            return Mapper.Map<Article, ArticleDTO>(articleFromService);
        }

        public ArticleDTO UpdateArticle(ArticleDTO articleDto)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ArticleDTO, Article>());
            Article articleForService = Mapper.Map<ArticleDTO, Article>(articleDto);
            Article articleFromService = client.UpdateArticle(articleForService);
            Mapper.Initialize(cfg => cfg.CreateMap<Article, ArticleDTO>());
            return Mapper.Map<Article, ArticleDTO>(articleFromService);
        }

        public int DeleteArticle(int id)
        {
            return client.DeleteArticle(id);
        }
    }
}
