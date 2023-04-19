using System;
using System.ComponentModel.DataAnnotations;
namespace LeMounAPI.Models
{
    // Model class for User Status table

    public class UserStatus
	{
		[Key]
		public long StatusId { get; set; }
		public string StatusName { get; set; }

		public UserStatus(string statusName)
		{
			StatusName = statusName;
		}
	}
}

