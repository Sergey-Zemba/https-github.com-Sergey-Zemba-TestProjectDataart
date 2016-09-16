using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NewsApp.DAL.Entities;
using NewsApp.DAL.Interfaces;

namespace NewsApp.DAL.Repositories
{
    public class ADOUnitOfWork : IUnitOfWork
    {
        private DatabaseProviderFactory factory;
        private Database database;
        private ArticleRepository articleRepository;

        public ADOUnitOfWork(string connectionString)
        {
            factory = new DatabaseProviderFactory();
            database = factory.Create(connectionString);
        }

        public IRepository<Article> Articles
        {
            get
            {
                if (articleRepository == null)
                {
                    articleRepository = new ArticleRepository(database);
                }
                return articleRepository;
            }
        }
        
    }
}
