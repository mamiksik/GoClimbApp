using System.Threading.Tasks;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MvvmCross.Platform;

namespace GoClimb.Core.Model
{
	public interface IHttpService
	{
		Task<Response> getRequest (string url);
	}

	public class HttpService : IHttpService
	{
		private HttpClient httpClient;

		public HttpService ()
		{
			//TODO: Should be injected from config
			httpClient = new HttpClient ();
		}

		public async Task<Response> getRequest (string url)
		{
			string baseUrl = "http://localhost/GoClimb/www/";
			//#if __ANDROID__
			//baseUrl = "http://10.0.2.2/GoClimb/www/";
			//#endif
			url = baseUrl + url + "?token=whmj7an5s0o4g2mlgj2h4pk2ptk1dlcm";
			Mvx.Warning (url);

			try {
				HttpResponseMessage httpResponse = await httpClient.GetAsync (url);
				Response response = JsonConvert.DeserializeObject<Response> (await httpResponse.Content.ReadAsStringAsync ());
				checkStatus (response.Status);
				return response;
			} catch (Exception e) {
				Mvx.TaggedTrace (typeof (HttpService).Name,
			 	"Ooops! Something went wrong fetching information for: {0}. Exception: {1}", url, e);
				return null;
			}
		}

		private void checkStatus (Status status)
		{
			switch (status.Code) {
			case "200":
				break;

			case "403":
				throw new UnAuthorizedException ();
				break;

			case "404":
				throw new NotFoundException ();
				break;

			//case "500":
			default:
				throw new BadRequestException ();
				break;
			}
		}
	}
}
