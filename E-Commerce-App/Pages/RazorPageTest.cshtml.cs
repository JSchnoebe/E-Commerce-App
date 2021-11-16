﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_App.Pages
{
    public class RazorPageTestModel : PageModel
    {
        public string Name { get; private set; }

        public void OnGet(string name)
        {
            Name = name;
        }
    }
}
