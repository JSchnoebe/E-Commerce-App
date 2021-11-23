﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Controllers;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using E_Commerce_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_App.Pages
{
    public class CategoriesDetailPageModel : PageModel
    {

        public Category Category { get; set; }

        public CartItem CartItem { get; set; }

        ICategoryRepository categoryRepository;

        ICartRepository cartRepository;

        public CategoriesDetailPageModel(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            Category = await categoryRepository.GetOne(id);

            //Bad id!
            if (Category == null)
                return NotFound();

            return Page();
        }

        //public async Task<IActionResult> AddProductToCart(int? id)
        //{
        //}
    }
}
