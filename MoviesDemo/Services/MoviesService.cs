using System.Collections.Generic;
using System.Linq;
using MoviesDemo.Models;
using MoviesDemo.Types;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MoviesDemo.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly IMongoCollection<Movie> _movies;

        public MoviesService(IOptions<MoviesDatabaseConfiguration> config)
        {
            var configMongo = config.Value;
            var client = new MongoClient(configMongo.ConnectionString);
            var database = client.GetDatabase(configMongo.DatabaseName);

            _movies = database.GetCollection<Movie>(configMongo.MoviesCollectionName);
        }

        public List<Movie> Get() => _movies.Find(movie => true).ToList();
        public Movie Get(string id) => _movies.Find<Movie>(movie => movie.MovieId == id).FirstOrDefault();

        public Movie Create(Movie movie)
        {
            _movies.InsertOne(movie);
            return movie;
        }

        public void Update(string id, Movie movieIn) => _movies.ReplaceOne(movie => movie.MovieId == id, movieIn);
        public void Remove(string id) => _movies.DeleteOne(movie => movie.MovieId == id);
    }
}