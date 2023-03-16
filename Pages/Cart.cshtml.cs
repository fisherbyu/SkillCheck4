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

        public ShoppingCart shoppingCart { get; set; }

        public string ReturnUrl { get; set; }

        public CartModel (IBookstoreRepository temp, ShoppingCart s)
        {
            repo = temp;
            shoppingCart = s;
        }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/"; //Get Url to return to
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            // Get the right book
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            shoppingCart.AddItem(b, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl }); //Redirect to previous page
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            shoppingCart.RemoveItem(shoppingCart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
