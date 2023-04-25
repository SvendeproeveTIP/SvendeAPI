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
		public long UserId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		// Foreign key for User Status table

		[ForeignKey("Status")]
		public long StatusId { get; set; }
		public virtual UserStatus Status { get; set; }

		// Foreign key for User Role table

		[ForeignKey("Role")]
		public long RoleId { get; set; }
		public virtual UserRole Role { get; set; }


		// A Collection of all Orders connected to the User Id
		public virtual ICollection<Order> Orders { get; set; }

		public User(string email, string password, long statusId, long roleId)
		{
			this.Email = email;
			this.Password = password;
			this.StatusId = statusId;
			this.RoleId = roleId;
		}
	}
}

