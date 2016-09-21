using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.DAL.Identity;

namespace NewsApp.DAL.Interfaces.IdentityInterfaces
{
    public interface IIdentityUnitOfWork : IDisposable
    {
        ApplicationUserManager UserManager { get; }
        IUserProfileManager UserProfileManager { get; }
        ApplicationRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
