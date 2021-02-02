using App.CommonHelper;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace App.Services
{
    public interface IApiServices
	{
        Task<T> GetObjectApi<T>(string ApiAction, object paramInput = null, string token = null);

    }
	public class ApiServices: IApiServices
    {
        
        public async Task<T> GetObjectApi<T>(string ApiAction, object paramInput = null, string token = null)
        {
            string ApiUrl = Common._baseUrl + ApiAction;
            var dataret = default(T);
            ApiUrl = ApiUrl + getParaUrl(paramInput);
            using (HttpClient client = new HttpClient())
            {
                addHeader(client, ApiUrl, token);
                HttpResponseMessage response;
                response = await client.GetAsync(client.BaseAddress);
                if (response.IsSuccessStatusCode)
                {
                    //string json
                    //var res = await response.Content.ReadAsStringAsync();
                    //dataret = res.toEntity<T>();
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
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
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
