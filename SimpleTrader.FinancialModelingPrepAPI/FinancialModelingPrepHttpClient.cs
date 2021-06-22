using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleTrader.FinancialModelingPrepAPI
{
    public class FinancialModelingPrepHttpClient : HttpClient
    {
        public FinancialModelingPrepHttpClient()
        {
            this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3");
        }
        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage responce = await GetAsync($"{uri}?=apikey=ded7fbeb58821884e6ee9eafd066eaaf");
            string jsonResonse = await responce.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResonse);
        }
    }
}
