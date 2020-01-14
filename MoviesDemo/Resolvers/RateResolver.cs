using System;
using MoviesDemo.Models;
using MoviesDemo.Services;
using HotChocolate;

namespace MoviesDemo.Resolvers
{
    public class RateResolver
    {
        private readonly IRateService _rateService;
        public RateResolver(IRateService service)
        {
            _rateService = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string GetRate(RateSource source, [Parent]Movie movie)
        {
            return _rateService.GetRate(source, movie.MovieId).Result;
        }
    }
}
