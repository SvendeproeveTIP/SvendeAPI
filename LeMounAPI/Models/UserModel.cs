﻿using System;
namespace LeMounAPI.Models
{
	public class UserModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public long StatusId { get; set; }
		public long RoleId { get; set; }
	}
}

