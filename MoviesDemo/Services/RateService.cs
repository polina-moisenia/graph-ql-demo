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
            var url = $"http://localhost:5052/api/rate/{movieId}/{source}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("The request to the rate service is done");
                return await response.Content.ReadAsStringAsync();;
            }

            return "0.0";
        }
    }
}