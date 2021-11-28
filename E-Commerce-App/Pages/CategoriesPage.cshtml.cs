using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Controllers;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_App.Pages
{
    public class CategoriesPageModel : PageModel
    {

        private readonly ECommerceDbContext _context;

        public IList<Category> Categories { get; set; }

        ICategoryRepository categoryRepository;

        public CategoriesPageModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task OnGetAsync()
        {
            Categories = await categoryRepository.GetAll();
        }
    }
}
