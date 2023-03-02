using System;
using System.Linq;

namespace Mission09_jazz3987.Models.ViewModels
{
	public class BookViewModel
	{
		public IQueryable<Book> Books { get; set; }

		public PageInfo PageInfo { get; set; }

	}
}

