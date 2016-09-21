using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NewsApp.DAL.EF;
using NewsApp.DAL.Entities;
using NewsApp.DAL.Identity;
using NewsApp.DAL.Interfaces;
using NewsApp.DAL.Interfaces.IdentityInterfaces;

namespace NewsApp.DAL.Repositories.IdentityRepos
{
    public class IdentityUnitOfWork : IIdentityUnitOfWork
    {
        private ApplicationContext db;
        private ApplicationUserManager userManager;
        private IUserProfileManager userProfileManager;
        private ApplicationRoleManager roleManager;

        public IdentityUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            userProfileManager = new UserProfileManager(db);
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
        }

        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IUserProfileManager UserProfileManager
        {
            get { return userProfileManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    userProfileManager.Dispose();
                    roleManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
