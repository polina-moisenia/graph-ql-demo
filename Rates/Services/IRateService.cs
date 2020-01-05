using System.Collections.Generic;
using Rates.Models;

namespace Rates.Services
{
    public interface IRateService
    {
        double GetRate(string movieId, RateSource source);
    }
}