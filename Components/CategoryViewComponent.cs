using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Mission09_jazz3987.Models;

namespace Mission09_jazz3987.Components
{
	public class CategoryViewComponent : ViewComponent
	{
		private IBookstoreRepository repo { get; set; }

		public CategoryViewComponent(IBookstoreRepository temp)
		{
			repo = temp;
		}

		public IViewComponentResult Invoke()
		{
			ViewBag.SelectedCategory = RouteData?.Values["category"];

			//Get categories
			var category = repo.Books
				.Select(x => x.Category)
				.Distinct()
				.OrderBy(x => x);

			return View(category);
		}
	}
}

