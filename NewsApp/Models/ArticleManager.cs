using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsApp.Models.Repository;

namespace NewsApp.Models
{
    public class ArticleManager
    {
        private SqlArticleRepository repository;

        public ArticleManager()
        {
            repository = new SqlArticleRepository();
        }

        public IEnumerable<Article> GetArticles(int page, out int numberOfPages)
        {
            int numberOfArticles;
            var result = repository.GetItems(page, out numberOfArticles);
            if (numberOfArticles%10 != 0)
            {
                numberOfPages = numberOfArticles/10 + 1;
            }
            else
            {
                numberOfPages = numberOfArticles/10;
            }
            return result;
        }

        public Article GetArticle(int id)
        {
            return repository.GetItem(id);
        }

        public void CreateArticle(Article article)
        {
            repository.Create(article);
        }

        public void UpdateArticle(Article article)
        {
            repository.Update(article);
        }

        public void DeleteArticle(int id)
        {
            repository.Delete(id);
        }
    }
}