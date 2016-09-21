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
        IEnumerable<T> GetItems(int page, out int numberOfItems);
        T GetItem(int id);
        T GetItem(T itemModel);
        int Create(T item);
        int Update(T item);
        int Delete(int id);
    }
}
