using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WCFDataService.Entities;
using WCFDataService.Interfaces;

namespace WCFDataService.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private Database database;
        public ArticleRepository(Database database)
        {
            this.database = database;
        }

        public IEnumerable<Article> GetItems(int page, out int numberOfItems)
        {
            using (DbCommand sqlCmd = database.GetSqlStringCommand("SELECT COUNT(*) FROM article"))
            {
                numberOfItems = Int32.Parse(database.ExecuteScalar(sqlCmd).ToString());
            }
            object[] parameters = { page };
            return database.ExecuteSprocAccessor<Article>("article_getArticles", parameters);
        }

        public Article GetItem(int id)
        {
            object[] parameters = { id };
            return database.ExecuteSprocAccessor<Article>("article_getArticle", parameters).FirstOrDefault();
        }


        public Article Create(Article article)
        {
            object[] parameters = { 0, article.Title, article.ShortDescription, article.Content, article.ImageName };
            return database.ExecuteSprocAccessor<Article>("article_addUpdate", parameters).FirstOrDefault();
        }

        public Article Update(Article article)
        {
            object[] parameters = { article.Id, article.Title, article.ShortDescription, article.Content, article.ImageName };
            return database.ExecuteSprocAccessor<Article>("article_addUpdate", parameters).FirstOrDefault();
        }

        public int Delete(int id)
        {
            object[] parameters = { id };
            return database.ExecuteNonQuery("article_delete", parameters);
        }
    }
}