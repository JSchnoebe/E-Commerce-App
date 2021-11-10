using System;
using E_Commerce_App.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_App.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
