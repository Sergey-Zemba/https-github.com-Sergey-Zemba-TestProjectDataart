﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.BLL.DTO;
using NewsApp.DAL.Entities;

namespace NewsApp.BLL.Interfaces
{
    public interface INewsService
    {
        IEnumerable<ArticleDTO> GetArticles(int page, out int numberOfPages);
        ArticleDTO GetArticle(int id);
        int CreateArticle(ArticleDTO articleDto);
        void UpdateArticle(ArticleDTO articleDto);
        void DeleteArticle(int id);

    }
}
