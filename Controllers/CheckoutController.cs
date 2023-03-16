using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission09_jazz3987.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission09_jazz3987.Controllers
{
    public class CheckoutController : Controller
    {
        private IPurchaseRepository repo { get; set; }

        private ShoppingCart shoppingCart { get; set; }

        public CheckoutController(IPurchaseRepository temp, ShoppingCart s)
        {
            repo = temp;
            shoppingCart = s;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (shoppingCart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = shoppingCart.Items.ToArray();
                repo.SavePurchase(purchase);
                shoppingCart.ClearCart();

                return RedirectToPage("/PurchaseComplete");
            }

            else
            {
                return View();
            }
        }
    }
}

