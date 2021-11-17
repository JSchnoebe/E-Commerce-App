﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMvc.Services;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Pages
{
    public class ShopperIndexModel : PageModel
    {
        private readonly ECommerceDbContext _context;
        private readonly IFileUploadService fileUploadService;

        public void OnGet()
        {
        }

        public IList<Category> Category { get; set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
