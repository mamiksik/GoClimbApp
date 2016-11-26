using System;
namespace GoClimb.Core.Model
{
	public class UnAuthorizedException: Exception
	{
		public UnAuthorizedException()
		{}
		
		public UnAuthorizedException(string msessage)
		{}
	}
	
	public class BadRequestException: Exception
	{
		public BadRequestException()
		{}
	
		public BadRequestException(string msessage)
		{}
	}
	
	public class NotFoundException: Exception
	{
		public NotFoundException()
		{}
	
		public NotFoundException(string msessage)
		{}
	}
}
