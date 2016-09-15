﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Models.Repository
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItems(int page, out int numberOfArticles);
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
