using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_App.Pages
{
    public class IndexModel : PageModel
    {
        [DisplayFormat(DataFormatString = "{0:hh:mm:ss tt}")]
        public DateTime PageGeneratedAt { get; private set; }

        public void OnGet()
        {
            PageGeneratedAt = DateTime.Now;
        }
    }
}
