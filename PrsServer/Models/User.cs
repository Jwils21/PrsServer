using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PrsServer.Models {
	public class User {
		public int Id { get; set; }
		[Required]
		[Index(IsUnique = true)]
		[StringLength(30)]
		public string UserName { get; set; }
		[Required]
		[StringLength(30)]
		public string Password { get; set; }
		[Required]
		[StringLength(30)]
		public string FirstName { get; set; }
		[Required]
		[StringLength(30)]
		public string LastName { get; set; }
		[Required]
		[StringLength(30)]
		public string Email { get; set; }
		[Required]
		[StringLength(12)]
		public string Phone { get; set; }
		[Required]
		public bool IsReviewer { get; set; } = false;
		[Required]
		public bool IsAdmin { get; set; } = false;
		[Required]
		public bool Active { get; set; } = true;


		public User() {

		}
	}
}