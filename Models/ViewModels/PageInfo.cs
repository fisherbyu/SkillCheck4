using System;
namespace Mission09_jazz3987.Models.ViewModels
{
	public class PageInfo
	{
		public int TotalNumBooks { get; set; }

		public int BooksPerPage { get; set; }

		public int CurrPage { get; set; }

		//Calculate number of pages
		public int TotalPages => (int) Math.Ceiling((double) TotalNumBooks / BooksPerPage);
	}
}

