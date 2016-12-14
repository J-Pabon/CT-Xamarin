using System;
using System.Net.Http;

namespace CT
{
	public class WebRequest
	{
		private static string URI_LOGIN = "http://139.59.134.177:4000/login";//"http://ct-test.azurewebsites.net/login";
		private static string URI_CASES = "http://139.59.134.177:4000/v1/cases";//"http://139.59.134.177:4000/v1/cases"

		private HttpClient httpClient;

		private HttpRequestMessage httpRequest;
		private HttpResponseMessage httpResponse;

		public WebRequest()
		{ }


	}
}
