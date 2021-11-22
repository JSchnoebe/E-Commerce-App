using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<List<Category>> GetNew(int count);
    }

    public class DatabaseCategoryRepository : ICategoryRepository
    {
        private readonly ECommerceDbContext _context;

        public DatabaseCategoryRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAll()
        {
            //return new List<Category>
            //{
            //    new Category { Id = 1, Name = "Games" },
            //    new Category { Id = 2, Name = "Books" },
            //    new Category { Id = 3, Name = "Toys" },
            //};
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetNew(int count)
        {
            return await _context.Categories
                .OrderByDescending(f => f.Id) // Sort newest to oldest
                .Take(count)
                .ToListAsync();
        }

        public async Task<Category> GetOne(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = await _context.Categories
                .Include(f => f.Products)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return null;
            }

            return category;
        }
    }
}