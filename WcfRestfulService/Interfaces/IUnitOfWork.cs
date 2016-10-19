using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfRestfulService.Entities;

namespace WcfRestfulService.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Article> Articles { get; }
    }
}
