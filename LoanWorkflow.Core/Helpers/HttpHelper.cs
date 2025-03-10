﻿using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;
using System.Xml.Serialization;

namespace LoanWorkflow.Core.Helpers
{
    public static class HttpHelper
    {
        public static async Task<TResponse> PostJson<TRequest, TResponse>(this HttpClient client, string url, TRequest model)
        {
            try
            {
                var body = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, MediaTypeNames.Application.Json);
                var response = await client.PostAsync(url, body);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }

        public static async Task<TResponse> PostUrlEncoded<TRequest, TResponse>(this HttpClient client, string url, TRequest model)
        {
            try
            {
                var pairs = Helpers.ToKeyValuePairs(model);
                var response = await client.PostAsync(url, new FormUrlEncodedContent(pairs));
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }

        public static async Task<TResponse> PostXml<TRequest, TResponse>(this HttpClient client, string url, TRequest model)
        {
            try
            {
                var body = new StringContent(Helpers.ToXml(model, out _), Encoding.UTF8, MediaTypeNames.Application.Xml);
                var response = await client.PostAsync(url, body);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(result);
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }

        public static async Task<TResponse> PostXml<TRequest, TResponse>(this HttpClient client, string url, TRequest request, string attributeName)
            where TRequest : class
            where TResponse : class
        {
            try
            {
                string xml = Helpers.ToXml(request, out _, attributeName);
                var content = GetHTTPContent(xml);
                var result = await client.PostAsync(url, content);
                var serializer = new XmlSerializer(typeof(TResponse));
                using var reader = new StringReader(await result.Content.ReadAsStringAsync());
                return serializer.Deserialize(reader) as TResponse;
            }
            catch (HttpRequestException)
            {
                return default;
            }
        }

        private static FormUrlEncodedContent GetHTTPContent(string requestString)
        {
            var values = new Dictionary<string, string>
            {
                { "query_xml", requestString }
            };

            return new FormUrlEncodedContent(values);
        }
    }
}