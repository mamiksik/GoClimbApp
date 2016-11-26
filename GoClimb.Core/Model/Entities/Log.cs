using System;

namespace GoClimb.Core.Model.Entities
{
	public class Log: BaseEntity
	{
		public int Id { get; set; }

		//public string Name { get; set; }

		public Object Style { get; set; }
		
		public string DateRemoved { get; set; }
		
		public Object Builder { get; set; }

		public Log(int id)
		{
			this.Id = id;
			//this.Name = Name;
		}
	}
}
