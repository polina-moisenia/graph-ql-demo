using System;
using Rates.Models;

namespace Rates.Services
{
    public class RateService : IRateService
    {        
        public double GetRate(string movieId, RateSource source)
        {
            switch(source)
            {
                case RateSource.Average:
                    return 5;
                    break;
                case RateSource.IMDB:
                    return 7.3;
                    break;
                case RateSource.Kinopoisk:
                    return 3.2;
                    break;
            }

            return 0.0;
        }
    }
}