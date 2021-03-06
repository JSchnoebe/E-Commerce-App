using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models.Identity
{
    public class RegisterData
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool AcceptedTerms { get; set; }

        public bool MakeMeAnEditor { get; set; }
    }
}
