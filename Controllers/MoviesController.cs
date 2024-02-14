using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesProject.Models;

namespace MoviesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _movieDbcontext;
        public MoviesController(MovieContext movieDbcontext)
        {
            _movieDbcontext = movieDbcontext;
        }


        // GET api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_movieDbcontext.Movies == null)
            {
                return NotFound();
            }
            return await _movieDbcontext.Movies.ToListAsync();
        }

        // GET api/Movies/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_movieDbcontext == null)
            {
                return NotFound();
            }
            var movie = await _movieDbcontext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }
        // POST api/Movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _movieDbcontext.Movies.Add(movie);
            await _movieDbcontext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);

        }

        //PUT api/Movies/3
        [HttpPut]
        public async Task<ActionResult<Movie>> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _movieDbcontext.Entry(movie).State = EntityState.Modified;
            try
            {
                await _movieDbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return NoContent();
        }

        // DELETE api/Movies/3
        [HttpDelete]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_movieDbcontext.Movies == null)
            {
                return NotFound();
            }

            var movie = await _movieDbcontext.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            _movieDbcontext.Movies.Remove(movie);
            await _movieDbcontext.SaveChangesAsync();
            return NoContent();
        }

        private bool MovieExist(long id)
        {
            return (_movieDbcontext.Movies?.Any(x => x.Id == id)).GetValueOrDefault();
        }


    }
}
