using System;
using System.ComponentModel.DataAnnotations;
namespace LeMounAPI.Models
{
    // Model class for User Role table

    public class UserRole
	{
		[Key]
		public int RoleId { get; set; }
		public string Role { get; set; }
	}
}

