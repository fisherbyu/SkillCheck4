using System;
using System.Linq;
namespace Mission09_jazz3987.Models
{
	public class EFBookstoreRepository : IBookstoreRepository
	{
		private BookstoreContext bookstoreContext { get; set; }

		public EFBookstoreRepository(BookstoreContext temp)
		{
			bookstoreContext = temp;
		}

		public IQueryable<Book> Books => bookstoreContext.Books;
	}
}

