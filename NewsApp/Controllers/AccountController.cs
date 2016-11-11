using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NewsApp.BLL.DTO;
using NewsApp.BLL.Interfaces;
using NewsApp.Models;

namespace NewsApp.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }
        
        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserViewModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO {Email = model.Email, Password = model.Password};
                ClaimsIdentity claim = await userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Incorrect login or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private async Task SetInitialDataAsync()
        {
            await userService.SetInitialData(new UserDTO
            {
                Email = "sergey.zemba@gmail.com",
                UserName = "sergey.zemba@gmail.com",
                Password = "qwerty",
                Name = "Sergey",
                Role = "user"
            }, new List<string> {"user"});
        }
    }
}