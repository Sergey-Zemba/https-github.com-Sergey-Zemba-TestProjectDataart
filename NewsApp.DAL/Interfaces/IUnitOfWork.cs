using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.DAL.Entities;
using NewsApp.DAL.Identity;

namespace NewsApp.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Article> Articles { get; }
    }
}
