using System.Collections.Generic;
using Demo.Models;

namespace Demo.Services
{
    public interface IRateService
    {
        string GetRate(RateSource source, string movieId);
    }
}