using System;
using System.Configuration;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace LeMounAPI.Models
{
    //Model class for User table

    public class User
	{
		[Key]
		public int UserId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		// Foreign key for User Status table

		[ForeignKey("Status")]
		public int StatusId { get; set; }
		public virtual UserStatus Status { get; set; }

		// Foreign key for User Role table

		[ForeignKey("Role")]
		public int RoleId { get; set; }
		public virtual UserRole Role { get; set; }


		// A Collection of all Orders connected to the User Id
		//public virtual ICollection<Order> Orders { get; set; }
	}
}

