using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission09_jazz3987.Models;
using Microsoft.EntityFrameworkCore;
using Mission09_jazz3987.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mission09_jazz3987.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController(IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BookViewModel
            {
                // Load up variables from view model
                Books = repo.Books
                .Where(x => x.Category == category || category == null)
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                // Adjust page numbers based on category
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (category == null
                    ? repo.Books.Count()
                    : repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrPage = pageNum
                }
            };
                
            return View(x);
        }
    }
}

