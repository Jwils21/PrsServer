using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrsServer.Models {
	public class Product {
		public int Id { get; set; }
		[Required]
		[StringLength(30)]
		public string PartNumber { get; set; }
		[Required]
		[StringLength(60)]
		public string Name { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required]
		[StringLength(30)]
		public string Unit { get; set; }
		[StringLength(120)]
		public string PhotoPath { get; set; }
		[Required]
		public bool Active { get; set; } = true;
		[Required]
		public int VendorId { get; set; }
		public virtual Vendor Vendor { get; set; }

		public Product() { }

	}
}