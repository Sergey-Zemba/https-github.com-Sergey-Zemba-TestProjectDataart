using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NewsApp.DAL.Entities;
using NewsApp.DAL.Interfaces;

namespace NewsApp.DAL.Repositories
{
    class ArticleRepository : IRepository<Article>
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
            object[] parameters = { 0, null, null, null, null, null, page, 4 };
            return database.ExecuteSprocAccessor<Article>("article_crud", parameters);
        }

        public Article GetItem(int id)
        {
            object[] parameters = { id, null, null, null, null, null, null, 5 };
            return database.ExecuteSprocAccessor<Article>("article_crud", parameters).FirstOrDefault();
        }

        public Article GetItem(Article articleModel)
        {
            return new Article();
        }

        public int Create(Article article)
        {
            object[] parameters = { 0, article.Title, article.ShortDescription, article.Content, article.ImageName, null, null, 1 };
            return database.ExecuteSprocAccessor<Article>("article_crud", parameters).First().Id;
        }

        public int Update(Article article)
        {
            object[] parameters = { article.Id, article.Title, article.ShortDescription, article.Content, article.ImageName, null, null, 2 };
            return database.ExecuteNonQuery("article_crud", parameters);
        }

        public int Delete(int id)
        {
            object[] parameters = { id, null, null, null, null, null, null, 3 };
            return database.ExecuteNonQuery("article_crud", parameters);
        }
    }
}
