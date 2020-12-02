using static MovieApi.Utils.MovieApiMessenger;
using MovieApi.Repository.Interface;
using Microsoft.Extensions.Logging;
using MovieApi.Factory.Interface;
using MovieApi.Mapping.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using System.Linq;
using System;

namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieApiController : ControllerBase
    {
        private readonly ILogger<MovieApiController> _logger;
        private readonly IObjFactory _objFactory;
        private readonly IMovieRepo _movieRepo;
        private readonly IMapper _mapper;

        public MovieApiController(IObjFactory objFactory,
            IMovieRepo movieRepo, IMapper mapper,
            ILogger<MovieApiController> logger)
        {
            _objFactory = objFactory;
            _movieRepo = movieRepo;
            _mapper = mapper;
            _logger = logger;
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetAllMovies")]
        [HttpGet]
        public IActionResult GetAllMovies()
        {
            _logger.LogInformation(GetAllMoviesEntry);

            var response = _objFactory.CreateResponse();

            try
            {
                var movies = _movieRepo.GetAll();

                if (movies.Any())
                {
                    _mapper.Map(response.Movies, movies, _objFactory);
                    _logger.LogInformation(MoviesReturned);
                }
                else
                {
                    response.Info = MoviesNotFound;
                    _logger.LogWarning(MoviesNotFound);
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("GetMovieById")]
        [HttpGet]
        public IActionResult GetMovieById(int id)
        {
            _logger.LogInformation(GetMovieByIdEntry(id));
            
            var response = _objFactory.CreateResponse();

            try
            {
                if (id > 0 && id <= _movieRepo.GetLastMovieId())
                {
                    var movie = _movieRepo.GetMovieById(id);

                    var movieModel = _objFactory.CreateMovieModel();
                    _mapper.Map(movieModel, movie);
                    response.Movies.Add(movieModel);

                    _logger.LogInformation(MovieFound(response.Movies[0].Title));
                }
                else
                {
                    response.Info = InvalidId;
                    _logger.LogWarning(InvalidIdPassed("GetMovieById", id));
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("CreateAMovie")]
        [HttpPost]
        public IActionResult CreateAMovie(MovieModel movieModel)
        {
            _logger.LogInformation(CreateMovieEntry(movieModel));

            var response = _objFactory.CreateResponse();

            try
            {
                var movie = _objFactory.CreateMovie();
                _mapper.Map(movie, movieModel);

                if (!_movieRepo.MovieExists(movie))
                {
                    var result = _movieRepo.CreateAMovie(movie);
                    response.Info = result == true ? AddSuccess : AddFailure;
                    _logger.LogInformation(ReturnWriteOperationMessage(result,
                        "Create", movieModel.Title));
                }
                else
                {
                    response.Info = AlreadyExists;
                    _logger.LogWarning(ReturnAlreadyExists(movieModel.Title));
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("UpdateAMovie")]
        [HttpPut]
        public IActionResult UpdateAMovie(int id, MovieModel movieModel)
        {
            _logger.LogInformation(UpdateMovieEntry(id, movieModel));

            var response = _objFactory.CreateResponse();

            try
            {
                if (id > 0 && id <= _movieRepo.GetLastMovieId())
                {
                    var movie = _movieRepo.GetMovieById(id);
                    _mapper.Map(movie, movieModel);
                    var result = _movieRepo.UpdateAMovie(movie);
                    response.Info = result == true ? UpdateSuccess : UpdateFailure;
                    _logger.LogInformation(ReturnWriteOperationMessage(result,
                        "Update", movieModel.Title));
                }
                else
                {
                    response.Info = InvalidId;
                    _logger.LogWarning(InvalidIdPassed("UpdateAMovie", id));
                }
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("DeleteAMovie")]
        [HttpDelete]
        public IActionResult DeleteAMovie(int id)
        {
            _logger.LogInformation(DeleteMovieEntry(id));

            var response = _objFactory.CreateResponse();

            try
            {
                if (id > 0 && id <= _movieRepo.GetLastMovieId())
                {
                    var movie = _movieRepo.GetMovieById(id);
                    var result = _movieRepo.DeleteAMovie(movie);
                    response.Info = result == true ? DeleteSuccess : DeleteFailure;
                    _logger.LogInformation(ReturnWriteOperationMessage(result,
                        "Delete", movie.Title));
                }
                else
                {
                    response.Info = InvalidId;
                    _logger.LogWarning(InvalidIdPassed("DeleteAMovie", id));
                } 
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(response);
        }
    }
}