using System.Threading.Tasks;
using MoviesDemo.Models;

namespace MoviesDemo.Services
{
    public interface IRateService
    {
        Task<string> GetRate(RateSource source, string movieId);
    }
}