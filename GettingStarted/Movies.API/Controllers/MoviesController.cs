using Microsoft.AspNetCore.Mvc;

namespace Movies.Api.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    public readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpPost("movies")]
    public async Task<IActionResult> Create([FromBody]CreateMovieRequest request)
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            YearOfRelease = request.YearofRelease,
            Genres = request.Genres.ToList()
        };
        await _movieRepository.CreateAsync(movie);
        return Created($"/api/movies/{movie.Id}", movie);
    }
} 