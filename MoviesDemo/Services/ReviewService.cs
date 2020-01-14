using System.Collections.Generic;
using System.Linq;
using MoviesDemo.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace MoviesDemo.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewService(IOptions<MoviesDatabaseConfiguration> config)
        {
            var configMongo = config.Value;
            var client = new MongoClient(configMongo.ConnectionString);
            var database = client.GetDatabase(configMongo.DatabaseName);

            _reviews = database.GetCollection<Review>(configMongo.ReviewsCollectionName);
        }

        public List<Review> GetAll()
        {
            Console.WriteLine("The request to the mongo DB for all reviews is done");
            return _reviews.Find(review => true).ToList();
        }
        public List<Review> GetReviewsByMovieId(string movieId)
        {
            Console.WriteLine($"The request to the mongo DB for review of the movie {movieId} is done");
            return _reviews.Find<Review>(review => review.MovieId == movieId).ToList();
        }
        public Review GetByReviewId(string reviewId) => _reviews.Find<Review>(review => review.ReviewId == reviewId).FirstOrDefault();

        public Review Create(Review review)
        {
            _reviews.InsertOne(review);
            return review;
        }

        public void Update(string id, Review reviewIn) => _reviews.ReplaceOne(review => review.ReviewId == id, reviewIn);
        public void Remove(string id) => _reviews.DeleteOne(review => review.ReviewId == id);
    }
}