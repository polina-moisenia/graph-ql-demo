using System;
using System.Net.Http;
using System.Threading.Tasks;
using MoviesDemo.Models;
using Microsoft.Extensions.Options;

namespace MoviesDemo.Services
{
    public class RateService : IRateService
    {
        private readonly IHttpClientFactory _clientFactory;

        public RateService(IOptions<RateServiceConfiguration> config, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<string> GetRate(RateSource source, string movieId)
        {
            var url = $"http://localhost:1002/api/rate/{movieId}/{source}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                byte[] byteArray = new byte[responseStream.Length];
                responseStream.Read(byteArray, 0, (int)responseStream.Length);                
                var value = System.Text.Encoding.UTF8.GetString(byteArray);
                return value;
            }

            return "0.0";
        }
    }
}