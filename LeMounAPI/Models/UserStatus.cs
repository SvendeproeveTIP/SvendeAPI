using System;
using System.ComponentModel.DataAnnotations;
namespace LeMounAPI.Models
{
    // Model class for User Status table

    public class UserStatus
	{
		[Key]
		public int StatusId { get; set; }
		public string StatusName { get; set; }
	}
}

