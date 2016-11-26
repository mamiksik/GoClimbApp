using System;
namespace GoClimb.Core.Model
{
	public class Status
	{
		public string Code { get; set; }

		public string Message { get; set; }

		public Status(string Code, string Message)
		{
			this.Code = Code;
			this.Message = Message;
		}

	}
}
