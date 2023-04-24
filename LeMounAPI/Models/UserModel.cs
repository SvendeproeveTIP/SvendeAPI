using System;
using System.Xml.Linq;

namespace LeMounAPI.Models
{
	public class UserModel
	{
		public long UserId { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public long StatusId { get; set; }
		public long RoleId { get; set; }
	}
}

