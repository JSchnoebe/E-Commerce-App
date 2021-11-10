using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
