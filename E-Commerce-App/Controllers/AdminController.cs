using System;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
