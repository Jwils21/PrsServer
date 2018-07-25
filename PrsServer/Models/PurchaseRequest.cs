using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrsServer.Models {
	public class PurchaseRequest {
		public int Id { get; set; }
		[Required]
		[StringLength(150)]
		public string Description { get; set; }
		[Required]
		[StringLength(255)]
		public string Justification { get; set; }
		[Required]
		[StringLength(25)]
		public string DeliveryMode { get; set; }
		[StringLength(30)]
		public string Status { get; set; } = "NEW";
		public decimal Total { get; set; } = 0;
		[Required]
		public bool Active { get; set; } = true;
		[StringLength(255)]
		public string ReasonForRejection { get; set; }
		[Required]
		public int UserId { get; set; }
		public virtual User User { get; set; }

		public virtual List<PurchaseRequestLineItem> PurchaseRequestLineitems { get; set; }

		public PurchaseRequest() { }

	}

}
