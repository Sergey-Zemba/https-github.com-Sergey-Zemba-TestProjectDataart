using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.DAL.EF;
using NewsApp.DAL.Entities;
using NewsApp.DAL.Interfaces;
using NewsApp.DAL.Interfaces.IdentityInterfaces;

namespace NewsApp.DAL.Repositories.IdentityRepos
{
    class UserProfileManager : IUserProfileManager
    {
        public ApplicationContext Database { get; set; }

        public UserProfileManager(ApplicationContext db)
        {
            Database = db;
        }

        public void Create(UserProfile item)
        {
            Database.UserProfiles.Add(item);
            Database.SaveChanges();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
