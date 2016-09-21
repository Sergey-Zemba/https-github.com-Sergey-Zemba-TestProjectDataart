using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFDataService.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetItems(int page, out int numberOfItems);
        T GetItem(int id);
        T Create(T item);
        T Update(T item);
        int Delete(int id);
    }
}
