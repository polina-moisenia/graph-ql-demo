using System;
using Demo.Models;
using Microsoft.Extensions.Options;

namespace Demo.Services
{
    public class RateService : IRateService
    {
        public RateService(IOptions<RateServiceConfiguration> config)
        {
            var httpConfig = config.Value;
            //pass to the http client
            Console.WriteLine(httpConfig.Url); 
        }
        
        public string GetRate(RateSource source, string movieId)
        {
            //do graph ql call to another service
            //http post with grapql body
            //lets make simple at first time and call just another API

            string rate = "not found";

            switch(source)
            {
                case RateSource.Average:
                    rate = "5";
                    break;
                case RateSource.IMDB:
                    rate = "7.3";
                    break;
                case RateSource.Kinopoisk:
                    rate = "3.2";
                    break;
            }

            return rate;
        }
    }
}