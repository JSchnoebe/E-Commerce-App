using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_Commerce_App.Data;
using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Services
{
    public interface ICartRepository
    {
    }

    public class DatabaseCartRepository : ICartRepository
    {
        private readonly ECommerceDbContext _context;

        public DatabaseCartRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<List<CartItem>> GetAll()
        {
            return await _context.CartItems.ToListAsync();
        }
    }
}
