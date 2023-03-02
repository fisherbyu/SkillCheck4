using System;
using System.Linq;
namespace Mission09_jazz3987.Models
{
	public interface IBookstoreRepository
	{
		IQueryable<Book> Books { get; }
	}
}

