using System;
using System.Threading.Tasks;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_App.Controllers
{
    public class AdminController : Controller
    {
        private readonly IDashboardRepository dashboard;

        public AdminController(IDashboardRepository dashboard)
        {
            this.dashboard = dashboard;
        }

        public async Task<IActionResult> Index()
        {
            int catCount = await dashboard.GetCategoryCount();
            int prodCount = await dashboard.GetProductCount();
            int orderCount = await dashboard.GetPendingOrderCount();

            var model = new AdminIndexViewModel
            {
                CategoryCount = catCount,
                ProductCount = prodCount,
                OrderCount = orderCount,
            };

            return View(model);
        }
    }
}
