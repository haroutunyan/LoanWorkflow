using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace LoanWorkflow.Core.Helpers
{
    public static class HttpHelper
    {
        public static async Task<TResponse> PostJson<TRequest, TResponse>(HttpClient client, string url, TRequest model)
        {
            var body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await client.PostAsync(url, body);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(result);
        }

        public static async Task<TResponse> PostUrlEncoded<TRequest, TResponse>(HttpClient client, string url, TRequest model)
        {
            var pairs = HelperMethods.ToKeyValuePairs(model);
            var response = await client.PostAsync(url, new FormUrlEncodedContent(pairs));
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponse>(result);
        }
    }
}
