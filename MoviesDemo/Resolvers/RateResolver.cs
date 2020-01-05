using System;
using MoviesDemo.Models;
using MoviesDemo.Services;
using HotChocolate;

namespace MoviesDemo.Resolvers
{
    public class RateResolver
    {
        private readonly IRateService _service;
        public RateResolver(IRateService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public string GetRate(RateSource source, [Parent]Movie movie)
        {
            return _service.GetRate(source, movie.MovieId).Result;
        }
    }
}
