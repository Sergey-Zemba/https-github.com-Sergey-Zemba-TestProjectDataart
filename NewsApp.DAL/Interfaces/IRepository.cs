using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.DAL.Entities;

namespace NewsApp.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItems(int page, out int numberOfArticles);
        T GetItem(int id);
        int Create(T item);
        Article Update(T item);
        Article Delete(int id);
    }
}
