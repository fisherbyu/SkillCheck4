using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mission09_jazz3987.Models
{
	public class Purchase
	{
		[Key]
		[BindNever]
		public int PurchaseId { get; set; }

		[BindNever]
		public ICollection<CartLineItem> Lines { get; set; }

		[Required(ErrorMessage = "Please enter your first name")]
		public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string LastName { get; set; }

		[Required(ErrorMessage = "Please enter the first address line")]
		public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

		[Required(ErrorMessage = "Please enter a city")]
		public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter ZIP")]
        public int Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country")]
        public string Country { get; set; }
    }
}

