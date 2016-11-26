using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
