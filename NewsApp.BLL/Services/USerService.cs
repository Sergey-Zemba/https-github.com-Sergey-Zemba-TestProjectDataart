using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using NewsApp.BLL.DTO;
using NewsApp.BLL.Infrastructure;
using NewsApp.BLL.Interfaces;
using NewsApp.DAL.Entities;
using NewsApp.DAL.Interfaces;
using NewsApp.DAL.Interfaces.IdentityInterfaces;

namespace NewsApp.BLL.Services
{
    public class UserService : IUserService
    {
        public IIdentityUnitOfWork Database { get; set; }

        public UserService(IIdentityUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            ApplicationUser user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                {
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                }
                await Database.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                UserProfile userProfile = new UserProfile { Id = user.Id, Name = userDto.Name };
                Database.UserProfileManager.Create(userProfile);
                await Database.SaveAsync();
                return new OperationDetails(true, "The registration was suceeded", "");
            }
            return new OperationDetails(false, "User with the same login already exists", "Email");
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            ApplicationUser user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user != null)
            {
                claim = await Database.UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
            }
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new ApplicationRole {Name = roleName};
                    await Database.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
