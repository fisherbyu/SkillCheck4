using System;
using System.Linq;

namespace Mission09_jazz3987.Models
{
	public interface IPurchaseRepository
	{
		IQueryable<Purchase> Purchases { get; }

		void SavePurchase(Purchase purchases);
	}
}

