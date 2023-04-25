using System;
namespace LeMounAPI.Repositories
{
	public class NotFoundException : Exception
	{
		public NotFoundException()
			: base(string.Format("NOT FOUND !!"))
		{
		}
	}
}

