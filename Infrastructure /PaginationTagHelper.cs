using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission09_jazz3987.Models.ViewModels;

namespace Mission09_jazz3987.Infrastructure
{
	[HtmlTargetElement("div", Attributes = "page-me")]
	public class PaginationTagHelper : TagHelper // Tag helper
	{
		//Create page links dynamically
		private IUrlHelperFactory uhf;

		public PaginationTagHelper(IUrlHelperFactory temp)
		{
			uhf = temp;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext vc { get; set; }

		public PageInfo PageMe { get; set; }

		public string PageAction { get; set; }

		//Extra tag helpers for style
		public bool PageClassesEnabled { get; set; } = false;

		public string PageClass { get; set; }

		public string PageClassNormal { get; set; }

		public string PageClassSelected { get; set; }

		public override void Process(TagHelperContext thc, TagHelperOutput tho)
		{
			IUrlHelper uh = uhf.GetUrlHelper(vc);
			//Build tags
			TagBuilder final = new TagBuilder("div");

			for (int i = 1; i <= PageMe.TotalPages; i++) //Create links for num total pages
			{
				TagBuilder tb = new TagBuilder("a");

				tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
				if (PageClassesEnabled) //Set style for page links
				{
					tb.AddCssClass(PageClass);
					tb.AddCssClass(i == PageMe.CurrPage
						? PageClassSelected : PageClassNormal);
				}
				tb.InnerHtml.Append(i.ToString());

				final.InnerHtml.AppendHtml(tb);
			}

			tho.Content.AppendHtml(final.InnerHtml);
		}
	}
}

