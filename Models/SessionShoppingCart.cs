using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission09_jazz3987.Infrastructure;

namespace Mission09_jazz3987.Models
{
	public class SessionShoppingCart : ShoppingCart
	{
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionShoppingCart shoppingCart = session?.GetJson<SessionShoppingCart>("shoppingCart") ?? new SessionShoppingCart();

            shoppingCart.Session = session;

            return shoppingCart;
        }

		[JsonIgnore]
		public ISession Session { get; set; }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("shoppingCart", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("shoppingCart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("shoppingCart");
        }
    }
}

