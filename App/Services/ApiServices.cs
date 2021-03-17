using App.CommonHelper;
using App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
	public interface IApiServices
	{
		Task<T> GetObjectApi<T>(string ApiAction, object paramInput = null, string token = null);
		Task<T> GetObjectApiByBody<T>(string ApiAction, object paramInput = null, string token = null, string ApiUrl = null);
		Task<T> PostObjectGSApi<T>(string ApiAction, object paramInput = null, string token = null, string ApiUrl = null);

	}
	public class ApiServices : IApiServices
	{

		public async Task<T> GetObjectApi<T>(string ApiAction, object paramInput = null, string token = null)
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			string ApiUrl = Common._baseUrl + ApiAction;
			var dataret = default(T);
			ApiUrl = ApiUrl + getParaUrl(paramInput);
			CookieContainer cookieContainer = new CookieContainer();
			var HttpClientHandler = new HttpClientHandler
			{
				CookieContainer = cookieContainer,
				ClientCertificateOptions = ClientCertificateOption.Automatic,
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
				AllowAutoRedirect = true,
				UseDefaultCredentials = false
			};
			using (HttpClient client = new HttpClient(HttpClientHandler))
			{
				addHeader(client, ApiUrl, token);
				HttpResponseMessage response;
				response = await client.GetAsync(client.BaseAddress);
				if (response.IsSuccessStatusCode)
				{
					//dataret = await response.Content.ReadAsAsync<T>();
					//string json
					var res = await response.Content.ReadAsStringAsync();
					dataret = res.toEntity<T>();

				}

			}
			return dataret;
		}
		public async Task<T> GetObjectApiByBody<T>(string ApiAction, object paramInput = null, string token = null, string ApiUrl = null)
		{
			if (string.IsNullOrEmpty(ApiUrl))
				ApiUrl = Common._baseUrl + ApiAction;
			else
				ApiUrl = ApiUrl + ApiAction;
			T dataret = default(T);
			using (HttpClient client = new HttpClient())
			{
				addHeader(client, ApiUrl, token);
				HttpResponseMessage response;
				StringContent content = new StringContent(JsonConvert.SerializeObject(paramInput, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				}), Encoding.UTF8, "application/json");
				HttpRequestMessage requestMessage = new HttpRequestMessage()
				{
					Content = content,
					RequestUri = client.BaseAddress,
					Method = HttpMethod.Get
				};
				response = await client.SendAsync(requestMessage);
				if (response.IsSuccessStatusCode)
				{
					dataret = await response.Content.ReadAsAsync<T>();
				}
			}
			return dataret;
		}
		public async Task<T> PostObjectGSApi<T>(string ApiAction, object paramInput = null, string token = null, string ApiUrl = null)
		{
			string _Url;
			if (string.IsNullOrEmpty(ApiUrl))
			{
				_Url = Common._baseUrl + ApiAction;
			}
			else
			{
				_Url = ApiUrl + ApiAction;
			}
			T dataret = default(T);
			using (HttpClient client = new HttpClient())
			{
				addHeader(client, _Url, token);
				HttpResponseMessage response;
				response = await client.PostAsJsonAsync(client.BaseAddress, paramInput);
				if (response.IsSuccessStatusCode)
				{
					dataret = await response.Content.ReadAsAsync<T>();
				}
			}
			return dataret;
		}
		private void addHeader(HttpClient client, string ApiUrl, string token)
		{
			client.BaseAddress = new Uri(ApiUrl);
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			//client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
			if (!string.IsNullOrEmpty(token))
			{
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
			}
			//client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.125 Safari/537.36");
		}
		private string getParaUrl(object paraInput)
		{
			if (paraInput != null)
			{
				var props = paraInput.GetType().GetProperties();
				string _paras = "";
				foreach (var p in props)
				{
					var _val = p.GetValue(paraInput, null);
					if (_val == null)
						continue;
					_val = Uri.EscapeDataString(_val.ToString());
					if (string.IsNullOrEmpty(_paras))
						_paras = string.Format("?{0}={1}", p.Name, _val);
					else
						_paras = _paras + string.Format("&{0}={1}", p.Name, _val);
				}
				return _paras;
			}
			return "";
		}
	}
}
