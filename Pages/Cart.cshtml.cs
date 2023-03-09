using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission09_jazz3987.Infrastructure;
using Mission09_jazz3987.Models;

namespace Mission09_jazz3987.Pages
{
	public class CartModel : PageModel
    {
        private IBookstoreRepository repo { get; set; }

        public CartModel (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public ShoppingCart shoppingCart { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/"; //Get Url to return to

            shoppingCart = HttpContext.Session.GetJson<ShoppingCart>("shoppingCart") ?? new ShoppingCart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            // Get the right book
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            shoppingCart = HttpContext.Session.GetJson<ShoppingCart>("shoppingCart") ?? new ShoppingCart();

            shoppingCart.AddItem(b, 1);

            HttpContext.Session.SetJson("shoppingCart", shoppingCart); //Set json file based on new shopping cart

            return RedirectToPage(new { ReturnUrl = returnUrl }); //Redirect to previous page
        }
    }
}
