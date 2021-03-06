using System;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce_App.Models.Identity
{
    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
