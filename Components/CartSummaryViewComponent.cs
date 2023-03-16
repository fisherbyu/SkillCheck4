using System;
using Microsoft.AspNetCore.Mvc;
using Mission09_jazz3987.Models;
namespace Mission09_jazz3987.Components

{
	public class CartSummaryViewComponent : ViewComponent
	{
		private ShoppingCart shoppingCart { get; set; }

		public CartSummaryViewComponent(ShoppingCart temp)
		{
			shoppingCart = temp;
		}

		public IViewComponentResult Invoke()
		{
			return View(shoppingCart);
		}
	}
}

