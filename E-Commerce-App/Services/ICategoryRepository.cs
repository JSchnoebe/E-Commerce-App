using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
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
    }
}