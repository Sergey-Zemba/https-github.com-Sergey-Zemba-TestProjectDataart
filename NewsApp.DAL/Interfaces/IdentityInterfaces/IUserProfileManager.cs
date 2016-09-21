using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.DAL.Entities;

namespace NewsApp.DAL.Interfaces.IdentityInterfaces
{
    public interface IUserProfileManager : IDisposable
    {
        void Create(UserProfile item);
    }
}
