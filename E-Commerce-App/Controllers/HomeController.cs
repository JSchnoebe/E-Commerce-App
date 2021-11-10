using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Commerce_App.Models;

namespace E_Commerce_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ICategoryRepository categoryRepository, ILogger<HomeController> logger)
        {
            this.categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Home!");
            List<Category> categories = await categoryRepository.GetAll();

            List<Category> newCategories = await categoryRepository.GetNew(5);

            return View(categories);
        }

        [HttpGet("PrivacyPolicy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("Test/404")]
        public IActionResult TestNotFound()
        {
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
