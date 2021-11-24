using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace E_Commerce_App.Models
{
    public class Product
    {
        private List<Product> Products;

        public int Id { get; set; }

        [Display(Name = "Product Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Price")]
        [Required]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Product> findAll()
        {
            return Products;
        }

        public Product find(int id)
        {
            return Products.Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
