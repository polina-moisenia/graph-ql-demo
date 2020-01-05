using System.Collections.Generic;
using MoviesDemo.Models;

namespace MoviesDemo.Services
{
    public interface IMoviesService
    {
        List<Movie> Get();
        Movie Get(string id);
        Movie Create(Movie movie);
        void Update(string id, Movie movieIn);
        void Remove(string id);
    }
}