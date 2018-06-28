using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrsServer.Models {
	public class Vendor {
		public int Id { get; set; }
		[Required]
		[Index(IsUnique = true)]
		[StringLength(6)]
		public string Code { get; set; }
		[Required]
		[StringLength(30)]
		public string Name { get; set; }
		[Required]
		[StringLength(80)]
		public string Address { get; set; }
		[Required]
		[StringLength(30)]
		public string City { get; set; }
		[Required]
		[StringLength(2)]
		public string State { get; set; }
		[Required]
		[StringLength(5)]
		public string Zip { get; set; }
		[Required]
		[StringLength(50)]
		public string Email { get; set; }
		[Required]
		public bool IsPreApproved { get; set; } = false;
		[Required]
		public bool Active { get; set; } = true;

		public Vendor() { }
	}

}