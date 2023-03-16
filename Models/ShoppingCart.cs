using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Mission09_jazz3987.Models
{
	public class ShoppingCart
	{
		public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

		public string RecentItem { get; set; } // Store added item and save to cart

		public virtual void AddItem(Book book, int qty)
		{
			CartLineItem line = Items
				.Where(b => b.Book.BookId == book.BookId)
				.FirstOrDefault();

			RecentItem = book.Title; // Set recent item

			if (line == null)  // Add item if not in the shopping cart
			{
				Items.Add(new CartLineItem
				{
					Book = book,
					Quantity = qty,
					Price = book.Price
				});
			}

			else //Add to existing count if in cart 
			{
				line.Quantity += qty;
			}
		}

		public virtual void RemoveItem(Book book) //Remove book with matching ID
		{
			Items.RemoveAll(x => x.Book.BookId == book.BookId);
		}

		public virtual void ClearCart() // Clear entire cart
		{
			Items.Clear();
		}

        public decimal CalcTotal()
		{
			decimal sum = Items.Sum(x => x.Quantity * x.Book.Price);

			return sum;
		}


    }

	public class CartLineItem
	{ 
		[Key] //Set key to create another table
		public int LineID { get; set; }

		public Book Book { get; set; }

		public int Quantity { get; set; }

		public decimal Price { get; set; }


	}
}

