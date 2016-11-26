using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using GoClimb.Core.Model.Entities;
using GoClimb.Core.Model;
using MvvmCross.Platform;

namespace GoClimb.Core.Model.Facades
{
	public interface ILogsFacade
	{
		Task<List<Log>> getAllLogs ();

		Task<Log> getLog (int logId);
	}

	public class LogsFacade : BaseFacade, ILogsFacade
	{

		private List<Log> logs = new List<Log>();

		public LogsFacade (IHttpService httpService) : base (httpService)
		{

		}

		public async Task<List<Log>> getAllLogs ()
		{
			if (logs.Count <= 0) {
				Response response = await httpService.getRequest ("api/en/v1/logs");
				logs = response.getListByKey<Log> ("logs");
			}

			Mvx.Warning (logs.Count.ToString());
			Mvx.Warning (logs [1].Id.ToString ());
			Mvx.Warning (logs.ToString ());

			return logs;
		}

		public async Task<Log> getLog (int logId)
		{
			Response response = await httpService.getRequest ("api/en/v1/logs/" + logId);
			return JsonConvert.DeserializeObject<Log> (response.Data["log"].ToString());
		}
	}
}
