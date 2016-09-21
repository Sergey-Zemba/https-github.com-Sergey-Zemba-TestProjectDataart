using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using NewsApp.DAL.Entities;

namespace NewsApp.DAL.EF
{
    class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string connectionString) : base(connectionString) { }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
