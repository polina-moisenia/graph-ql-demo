using System;
using MoviesDemo.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using HotChocolate;

namespace MoviesDemo.Resolvers
{
    public class RateResolver
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string BaseUrl;

        public RateResolver(IOptions<RateServiceConfiguration> config, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            BaseUrl = config.Value.Url;
        }

        public async Task<string> GetRate(RateSource source, [Parent]Movie movie)
        {
            var url = $"{BaseUrl}/{movie.MovieId}/{source}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            try
            {
                var client = _clientFactory.CreateClient();
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("The request to the rate service is done");
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rate getting ended with an error {ex}");
            }
            return "0.0";
        }
    }
}
