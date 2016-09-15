using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace NewsApp.Models.Repository
{
    public class SqlArticleRepository : IRepository<Article>
    {
        private DatabaseProviderFactory factory;
        private Database database;
        public SqlArticleRepository()
        {
            factory = new DatabaseProviderFactory();
            database = factory.Create("MSSqlConnection");
        }

        public IEnumerable<Article> GetItems(int page, out int numberOfArticles)
        {
            using (DbCommand sqlCmd = database.GetSqlStringCommand("SELECT COUNT(*) FROM article"))
            {
                numberOfArticles = Int32.Parse(database.ExecuteScalar(sqlCmd).ToString());
            }
            object[] parameters = { 0, null, null, null, null, null, page, 4 };
            return database.ExecuteSprocAccessor<Article>("article_crud", parameters);
        }

        public Article GetItem(int id)
        {
            object[] parameters = { id, null, null, null, null, null, null, 5 };
            return database.ExecuteSprocAccessor<Article>("article_crud", parameters).FirstOrDefault();
        }

        public void Create(Article article)
        {
            object[] parameters = { 0, article.Title, article.ShortDescription, article.Content, article.PicturePath, null, null, 1 };
            database.ExecuteSprocAccessor<Article>("article_crud", parameters);
        }

        public void Update(Article article)
        {
            object[] parameters = { article.Id, article.Title, article.ShortDescription, article.Content, article.PicturePath, null, null, 2 };
            database.ExecuteSprocAccessor<Article>("article_crud", parameters);
        }

        public void Delete(int id)
        {
            object[] parameters = { id, null, null, null, null, null, null, 3 };
            database.ExecuteSprocAccessor<Article>("article_crud", parameters);
        }
    }
}