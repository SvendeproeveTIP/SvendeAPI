using System;
namespace LeMounAPI.Services
{
	public class IdNotFoundException : Exception
	{
		public IdNotFoundException(long id)
			:base(String.Format(" ID not found!", id))
		{

		}
	}
}

