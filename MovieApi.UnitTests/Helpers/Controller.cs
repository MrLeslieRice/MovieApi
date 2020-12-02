using static MovieApi.UnitTests.Helpers.FakeObjFactory;
using static MovieApi.UnitTests.Helpers.FakeMovieDb;
using NSubstitute.ExceptionExtensions;
using MovieApi.Repository.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using MovieApi.Mapping.Interface;
using MovieApi.Factory.Interface;
using MovieApi.Controllers;
using MovieApi.DAL.Models;
using MovieApi.Models;
using NSubstitute;
using System;

namespace MovieApi.UnitTests.Helpers
{
    public static class Controller
    {
        #region CommonSetup

        private static ILogger<MovieApiController> _logger;
        private static MovieApiResponse _response;
        private static IObjFactory _objFactory;
        private static IMovieRepo _movieRepo;
        private static IMapper _mapper;

        private static void CommonSetup()
        {
            _response = FakeObjFactory.CreateResponse();

            _objFactory = Substitute.For<IObjFactory>();
            _objFactory.CreateResponse().Returns(_response);

            _movieRepo = Substitute.For<IMovieRepo>();
            _mapper = Substitute.For<IMapper>();
            _logger = Substitute.For<ILogger<MovieApiController>>();
        }

        #endregion CommonSetup

        #region GetAllMovies Setups

        public static MovieApiController GetAllMoviesHappySetup()
        {
            CommonSetup();
            _movieRepo.GetAll().Returns(ReturnMovies());
            _mapper.When(x => x.Map(_response.Movies, Arg.Any<List<Movie>>(), _objFactory))
                .Do(x => _response.Movies = ReturnMovieModels());
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController GetAllMoviesEmptyListSetup()
        {
            CommonSetup();
            List<Movie> movies = new List<Movie>();
            _movieRepo.GetAll().Returns(movies);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController GetAllMoviesNullListSetup()
        {
            CommonSetup();
            List<Movie> movies = null;
            _movieRepo.GetAll().Returns(movies);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        #endregion GetAllMovies Setups

        #region GetMovieById Setups

        public static MovieApiController GetMovieByIdHappySetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Returns(3);
            _movieRepo.GetMovieById(1).Returns(ReturnMovie());
            _objFactory.CreateMovieModel().Returns(CreateMovieModel());
            _mapper.When(x => x.Map(Arg.Any<MovieModel>(), Arg.Any<Movie>()))
                .Do(x => _response.Movies = ReturnMovieModel());
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController GetMovieByIdInvalidIdSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Returns(3);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController GetMovieByIdExceptionSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Returns(3);
            _movieRepo.GetMovieById(Arg.Any<int>())
                .Throws(new Exception("An exception has occurred."));
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        #endregion GetMovieById Setups

        #region CreateAMovie Setups

        private static Movie CommonCreateSetup()
        {
            var movie = FakeObjFactory.CreateMovie();
            var movieReturned = ReturnMovie();

            _objFactory.CreateMovie().Returns(movie);

            _mapper.When(x => x.Map(Arg.Any<Movie>(), Arg.Any<MovieModel>()))
                .Do(x => movie = movieReturned);

            return movie;
        }

        public static MovieApiController CreateAMovieHappySetup()
        {
            CommonSetup();
            var movie = CommonCreateSetup();
            _movieRepo.MovieExists(movie).Returns(false);
            _movieRepo.CreateAMovie(movie).Returns(true);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController CreateAMovieAddFailureSetup()
        {
            CommonSetup();
            var movie = CommonCreateSetup();
            _movieRepo.MovieExists(movie).Returns(false);
            _movieRepo.CreateAMovie(movie).Returns(false);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController CreateAMovieAlreadyExistsSetup()
        {
            CommonSetup();
            var movie = CommonCreateSetup();
            _movieRepo.MovieExists(movie).Returns(true);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController CreateAMovieExceptionSetup()
        {
            CommonSetup();
            var movie = CommonCreateSetup();
            _movieRepo.MovieExists(movie).Throws(new Exception("An exception has occurred."));
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        #endregion CreateAMovie Setups

        #region UpdateAMovie Setups

        private static Movie CommonUpdateSetup()
        {
            var movie = ReturnMovie();

            _movieRepo.GetLastMovieId().Returns(3);
            _movieRepo.GetMovieById(Arg.Any<int>()).Returns(movie);

            _mapper.When(x => x.Map(movie, Arg.Any<MovieModel>()))
                .Do(x => movie = ReturnMovie());

            return movie;
        }

        public static MovieApiController UpdateAMovieHappySetup()
        {
            CommonSetup();
            var movie = CommonUpdateSetup();
            _movieRepo.UpdateAMovie(movie).Returns(true);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController UpdateAMovieUpdateFailureSetup()
        {
            CommonSetup();
            var movie = CommonUpdateSetup();
            _movieRepo.UpdateAMovie(movie).Returns(false);

            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController UpdateAMovieInvalidIdSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Returns(3);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController UpdateAMovieExceptionSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Throws(new Exception("An exception has occurred."));
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        #endregion UpdateAMovie Setups

        #region DeleteAMovie Setups

        public static MovieApiController DeleteAMovieHappyPathSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Returns(3);
            _movieRepo.GetMovieById(Arg.Any<int>()).Returns(ReturnMovie());
            _movieRepo.DeleteAMovie(Arg.Any<Movie>()).Returns(true);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController DeleteAMovieDeleteFailureSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Returns(3);
            _movieRepo.GetMovieById(Arg.Any<int>()).Returns(ReturnMovie());
            _movieRepo.DeleteAMovie(Arg.Any<Movie>()).Returns(false);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController DeleteAMovieInvalidIdSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Returns(3);
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        public static MovieApiController DeleteAMovieExceptionSetup()
        {
            CommonSetup();
            _movieRepo.GetLastMovieId().Throws(new Exception("An exception has occurred."));
            return new MovieApiController(_objFactory, _movieRepo, _mapper, _logger);
        }

        #endregion DeleteAMovie Setups
    }
}
