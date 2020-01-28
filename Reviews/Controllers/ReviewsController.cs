using System.Collections.Generic;
using Reviews.Models;
using Reviews.Services;
using Microsoft.AspNetCore.Mvc;

namespace Reviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : Controller
    {
        private readonly IReviewsService _reviewsService;

        public ReviewsController(IReviewsService reviewsService)
        {
            _reviewsService = reviewsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> Get() => _reviewsService.Get();

        [HttpGet("{id:length(3)}")]
        public ActionResult<Review> Get(string id)
        {
            var review = _reviewsService.Get(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        [HttpPost]
        public ActionResult<Review> Create(Review review)
        {
            _reviewsService.Create(review);

            return CreatedAtRoute("GetReview", new { id = review.ReviewId.ToString() }, review);
        }

        [HttpPut("{id:length(3)}")]
        public IActionResult Update(string id, Review reviewIn)
        {
            var review = _reviewsService.Get(id);

            if (review == null)
            {
                return NotFound();
            }

            _reviewsService.Update(id, reviewIn);

            return NoContent();
        }

        [HttpDelete("{id:length(3)}")]
        public IActionResult Delete(string id)
        {
            var review = _reviewsService.Get(id);

            if (review == null)
            {
                return NotFound();
            }

            _reviewsService.Remove(review.Id);

            return NoContent();
        }
    }
}