using System.Collections.Generic;
using Demo.Models;

namespace Demo.Services
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