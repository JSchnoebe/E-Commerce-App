using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Controllers
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetNew(int count);
    }

    public class DatabaseProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public DatabaseProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetNew(int count)
        {
            return await _context.Products
                .OrderByDescending(f => f.Id) // Sort newest to oldest
                .Take(count)
                .ToListAsync();
        }
    }
}
