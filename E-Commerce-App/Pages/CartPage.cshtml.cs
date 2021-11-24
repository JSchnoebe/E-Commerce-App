using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce_App.Helpers;
using E_Commerce_App.Models;
using E_Commerce_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Commerce_App.Pages
{
    public class CartPageModel : PageModel
    {

        ICartRepository cartRepository;

        public List<CartItem> CartItems;

        public decimal Total { get; set; }

        public CartPageModel(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public void OnGet()
        {
            CartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            Total = CartItems.Sum(i => i.Product.Price * i.Quantity);
        }

        public IActionResult OnGetBuyNow(int id)
        {
            var productModel = new Product();
            CartItems = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart");
            if (CartItems == null)
            {
                CartItems = new List<CartItem>();
                CartItems.Add(new CartItem
                {
                    Product = productModel.find(id),
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", CartItems);
            }
            else
            {
                int index = Exists(CartItems, id);
                if (index == -1)
                {
                    CartItems.Add(new CartItem
                    {
                        Product = productModel.find(id),
                        Quantity = 1
                    });
                }
                else
                {
                    CartItems[index].Quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", CartItems);
            }
            return RedirectToPage("Cart");
        }

        private int Exists(List<CartItem> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (CartItems[i].Product.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
