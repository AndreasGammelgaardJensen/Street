using Newtonsoft.Json;
using Street.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Street.Services
{
    internal class BaseWebApi
    {
        private readonly string _baseApi = "http://10.0.2.2:5126/api/";

        private HttpClient _client = new HttpClient();
        protected HttpClient client
        {
            get => _client;
        }

        public Task<HttpResponseMessage> PostAsync<T>(string uri, T groupDto)
        {
            var json = JsonConvert.SerializeObject(groupDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return client.PostAsync(new Uri(GetUrl(uri)), content);
        }

        public Task<HttpResponseMessage> GetAsync(string uri)
        {
            return client.GetAsync(new Uri(GetUrl(uri)));
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri)
        {
            return client.DeleteAsync(new Uri(GetUrl(uri)));
        }

        private string GetUrl(string uri)
        {
            var url = string.Format("{0}{1}", _baseApi, uri);
            return url;
        }
    }
}
