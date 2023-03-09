using System;
using Microsoft.AspNetCore.Http;

namespace Mission09_jazz3987.Infrastructure
{
	public static class UrlExtensions
	{
		public static string PathAndQuery(this HttpRequest request) =>
			request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();


	}
}

