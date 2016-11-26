using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoClimb.Core.Model
{
	public class Response
	{
		public Status Status { get; set; }

		public JObject Data { get; set; }

		public Response(Status Status, JObject Data)
		{
			this.Status = Status;
			this.Data = Data;
		}

		public List<T> getListByKey<T>(string key)
		{
			List<T> list = new List<T>();
			foreach (var child in Data[key].Children())
			{
				list.Add(JsonConvert.DeserializeObject<T>(child.First.ToString()));
			}

			return list;
		}
	}
}
