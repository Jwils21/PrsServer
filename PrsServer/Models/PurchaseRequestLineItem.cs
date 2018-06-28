using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrsServer.Models {
	public class PurchaseRequestLineItem {
		public int Id { get; set; }
		[Required]
		public int Quantity { get; set; } = 1;
		[Required]
		public bool Active { get; set; } = true;
		[Required]
		public int ProductId { get; set; }
		public virtual Product Product { get; set; }
		[Required]
		public int PurchaseRequestId { get; set; }
		public virtual PurchaseRequest PurchaseRequest { get; set; }

		public PurchaseRequestLineItem() { }

	}
}