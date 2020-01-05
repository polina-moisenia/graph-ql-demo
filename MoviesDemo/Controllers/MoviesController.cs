using System.Collections.Generic;
using MoviesDemo.Models;
using MoviesDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace MoviesDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get() => _moviesService.Get();

        [HttpGet("{id:length(3)}")]
        public ActionResult<Movie> Get(string id)
        {
            var movie = _moviesService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        [HttpPost]
        public ActionResult<Movie> Create(Movie movie)
        {
            _moviesService.Create(movie);

            return CreatedAtRoute("GetMovie", new { id = movie.MovieId.ToString() }, movie);
        }

        [HttpPut("{id:length(3)}")]
        public IActionResult Update(string id, Movie movieIn)
        {
            var movie = _moviesService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _moviesService.Update(id, movieIn);

            return NoContent();
        }

        [HttpDelete("{id:length(3)}")]
        public IActionResult Delete(string id)
        {
            var movie = _moviesService.Get(id);

            if (movie == null)
            {
                return NotFound();
            }

            _moviesService.Remove(movie.Id);

            return NoContent();
        }
    }
}