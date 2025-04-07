using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_asp_net.Models;

namespace project_asp_net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        // GET: api/movie
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _context.Movies.ToListAsync();
            return Ok(movies);
        }

        // POST: api/movie
        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovies), new { id = movie.id }, movie);
        }
    }
}
