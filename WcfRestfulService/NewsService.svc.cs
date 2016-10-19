using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfRestfulService.Entities;
using WcfRestfulService.Interfaces;
using WcfRestfulService.Repositories;

namespace WcfRestfulService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NewsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select NewsService.svc or NewsService.svc.cs at the Solution Explorer and start debugging.
    public class NewsService : INewsService
    {
        public IUnitOfWork Database { get; set; }

        public NewsService()
        {
            Database = new ADOUnitOfWork("MSSqlConnection");
        }

        public IEnumerable<Article> GetArticles(string page, out int numberOfItems)
        {
            return Database.Articles.GetItems(Int32.Parse(page), out numberOfItems);
        }

        public Article GetArticle(string id)
        {
            return Database.Articles.GetItem(Int32.Parse(id));
        }

        public Article CreateArticle(Article item)
        {
            return Database.Articles.Create(item);
        }

        public Article UpdateArticle(Article item)
        {
            return Database.Articles.Update(item);
        }

        public int DeleteArticle(string id)
        {
            return Database.Articles.Delete(Int32.Parse(id));
        }
    }
}
