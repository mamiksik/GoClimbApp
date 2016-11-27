using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GoClimb.Core.Service;

namespace GoClimb.Core.Model.Facades
{
	public abstract class BaseFacade
	{
		protected IHttpService httpService;

		public BaseFacade(IHttpService httpService)
		{
			this.httpService = httpService;
		}
	}
}
