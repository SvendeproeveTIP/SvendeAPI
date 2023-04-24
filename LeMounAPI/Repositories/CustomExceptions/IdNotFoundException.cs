using System;
namespace LeMounAPI.Repositories.CustomExceptions
{
	public class IdNotFoundException : Exception
	{
		public IdNotFoundException(long id)
			:base(String.Format(" ID not found!", id))
		{

		}
	}
}

