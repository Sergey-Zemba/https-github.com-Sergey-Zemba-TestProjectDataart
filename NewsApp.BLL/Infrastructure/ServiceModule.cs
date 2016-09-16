using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.DAL.Interfaces;
using NewsApp.DAL.Repositories;
using Ninject.Modules;

namespace NewsApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<ADOUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
