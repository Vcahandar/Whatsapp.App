using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Whatsapp.App.Models;

namespace Whatsapp.App.Controllers
{
    public class HomeController : Controller
    {
        readonly UserManager<AppUser> _userMAnager;

        public HomeController(UserManager<AppUser> userMAnager)
        {
            _userMAnager = userMAnager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userMAnager.Users.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}