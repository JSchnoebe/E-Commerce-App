using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Models;
using E_Commerce_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_App.Pages
{
    public class CartPageModel : PageModel
    {

        ICartRepository cartRepository;

        public IList<CartItem> CartItems;

        public CartPageModel(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public async Task OnGetAsync()
        {
            CartItems = await cartRepository.GetAll();
        }
    }
}
