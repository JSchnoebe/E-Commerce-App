using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Models.Identity;
using E_Commerce_App.Services.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterData data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            await userService.Register(data, ModelState);

            if (!ModelState.IsValid)
            {
                return View(data);
            }

            // Post - Get to avoid "do you want to resubmit?"
            return RedirectToAction(nameof(Index));
        }
    }
}