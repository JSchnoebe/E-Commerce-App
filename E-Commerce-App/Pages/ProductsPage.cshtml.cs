using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Controllers;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Pages
{
    public class ProductsPageModel : PageModel
    {
        private readonly ECommerceDbContext _context;

        public IList<Product> Products { get; set; }

        IProductRepository productRepository;

        public ProductsPageModel(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task OnGetAsync()
        {
            Products = await productRepository.GetAll();
        }
    }
}
