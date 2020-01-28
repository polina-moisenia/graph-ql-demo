using System.Collections.Generic;
using System.Linq;
using Reviews.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace Reviews.Services
{
    public class ReviewsService : IReviewsService
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewsService(IOptions<DatabaseConfiguration> config)
        {
            var configMongo = config.Value;
            var client = new MongoClient(configMongo.ConnectionString);
            var database = client.GetDatabase(configMongo.DatabaseName);

            _reviews = database.GetCollection<Review>(configMongo.ReviewsCollectionName);
        }

        public List<Review> Get()
        {
            Console.WriteLine("The request to the mongo DB for all reviews is done");
            return _reviews.Find(review => true).ToList();
        }
        
        public Review Get(string id) {
            Console.WriteLine($"The request to the mongo DB for review {id} is done");
            return _reviews.Find<Review>(review => review.ReviewId == id).FirstOrDefault();
        }

        public List<Review> GetByMovieId(string movieId) {
            Console.WriteLine($"The request to the mongo DB for movieId {movieId} is done");
            return _reviews.Find<Review>(review => review.MovieId == movieId).ToList();
        }

        public Review Create(Review review)
        {
            _reviews.InsertOne(review);
            return review;
        }

        public void Update(string id, Review reviewIn) => _reviews.ReplaceOne(review => review.ReviewId == id, reviewIn);
        public void Remove(string id) => _reviews.DeleteOne(review => review.ReviewId == id);
    }
}