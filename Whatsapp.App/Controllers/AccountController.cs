using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Whatsapp.App.Models;
using Whatsapp.App.ViewModels;

namespace Whatsapp.App.Controllers
{
    public class AccountController : Controller
    {
        readonly UserManager<AppUser> userManager;
        readonly SignInManager<AppUser> signInManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await userManager.FindByNameAsync(dto.UserName);

            if(user == null)
            {
                ModelState.AddModelError("","Username or password incorrect");
                return View();
            }

           var result= await signInManager.PasswordSignInAsync(user,dto.Password,false,false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password incorrect");
                return View();
            }
            return RedirectToAction("Index","Home");
        }

    }
}
