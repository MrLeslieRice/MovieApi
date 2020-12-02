using static MovieApi.UnitTests.Helpers.FakeObjFactory;
using static MovieApi.UnitTests.Helpers.Controller;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using MovieApi.Models;

namespace MovieApi.UnitTests
{
    public class MovieApiControllerTests
    {
        #region GetAllMovies Tests

        [Test]
        public void GetAllMovies_HappyPath_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = GetAllMoviesHappySetup();
            var expected = 200;

            // Act
            var actual = movieController.GetAllMovies() as OkObjectResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public void GetAllMovies_HappyPath_ReturnsCorrectNoOfMovies()
        {
            // Arrange
            var movieController = GetAllMoviesHappySetup();
            var expected = 3;

            // Act
            var response = movieController.GetAllMovies() as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Movies.Count);
        }

        [Test]
        public void GetAllMovies_EmptyMovieList_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = GetAllMoviesEmptyListSetup();
            var expected = "No movies could be found.";

            // Act
            var response = movieController.GetAllMovies() as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Asssert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void GetAllMovies_NullMovieList_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = GetAllMoviesNullListSetup();
            var expected = 500;

            // Act
            var actual = movieController.GetAllMovies() as StatusCodeResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        #endregion GetAllMovies Tests

        #region GetMovieById Tests

        [Test]
        public void GetMovieById_HappyPath_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = GetMovieByIdHappySetup();
            var expected = 200;

            // Act
            var actual = movieController.GetMovieById(1) as OkObjectResult;

            // Assign
            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public void GetMovieById_HappyPath_ReturnsCorrectMovie()
        {
            // Arrange
            var movieController = GetMovieByIdHappySetup();
            var expected = "Fight Club";

            // Act
            var response = movieController.GetMovieById(1) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assign
            Assert.AreEqual(expected, actual.Movies[0].Title);
        }

        [Test]
        public void GetMovieById_InvalidId_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = GetMovieByIdInvalidIdSetup();
            var expected = "Invalid Id was passed.";

            // Act
            var response = movieController.GetMovieById(4) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void GetMovieById_GivenException_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = GetMovieByIdExceptionSetup();
            var expected = 500;

            // Act
            var actual = movieController.GetMovieById(3) as StatusCodeResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        #endregion GetMovieById Tests

        #region CreateAMovie Tests

        [Test]
        public void CreateAMovie_HappyPath_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = CreateAMovieHappySetup();
            var movieModel = CreateMovieModel();
            var expected = 200;

            // Act
            var actual = movieController.CreateAMovie(movieModel) as OkObjectResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public void CreateAMovie_HappyPath_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = CreateAMovieHappySetup();
            var movieModel = CreateMovieModel();
            var expected = "Movie was added successfully!";

            // Act
            var response = movieController.CreateAMovie(movieModel) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void CreateAMovie_AddFailure_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = CreateAMovieAddFailureSetup();
            var movieModel = CreateMovieModel();
            var expected = "Movie failed to be added.";

            // Act
            var response = movieController.CreateAMovie(movieModel) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void CreateAMovie_AlreadyExists_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = CreateAMovieAlreadyExistsSetup();
            var movieModel = CreateMovieModel();
            var expected = "That movie already exists in the database.";

            // Act
            var response = movieController.CreateAMovie(movieModel) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void CreateAMovie_GivenException_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = CreateAMovieExceptionSetup();
            var expected = 500;

            // Act
            var actual = movieController.CreateAMovie(CreateMovieModel()) as StatusCodeResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        #endregion CreateAMovie Tests

        #region UpdateAMovie Tests

        [Test]
        public void UpdateAMovie_HappyPath_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = UpdateAMovieHappySetup();
            var expected = 200;

            // Act
            var actual = movieController.UpdateAMovie(2, CreateMovieModel()) as OkObjectResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public void UpdateAMovie_HappyPath_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = UpdateAMovieHappySetup();
            var expected = "Movie was updated successfully!";

            // Act
            var response = movieController.UpdateAMovie(2, CreateMovieModel()) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void UpdateAMovie_UpdateFailure_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = UpdateAMovieUpdateFailureSetup();
            var expected = "Movie failed to update.";

            // Act
            var response = movieController.UpdateAMovie(3, CreateMovieModel()) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void UpdateAMovie_InvalidId_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = UpdateAMovieInvalidIdSetup();
            var expected = "Invalid Id was passed.";

            // Act
            var response = movieController.UpdateAMovie(8, CreateMovieModel()) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void UpdateAMovie_GivenException_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = UpdateAMovieExceptionSetup();
            var expected = 500;

            // Act
            var actual = movieController.UpdateAMovie(3, CreateMovieModel()) as StatusCodeResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        #endregion UpdateAMovie Tests

        #region DeleteAMovie Tests

        [Test]
        public void DeleteAMovie_HappyPath_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = DeleteAMovieHappyPathSetup();
            var expected = 200;

            // Act
            var actual = movieController.DeleteAMovie(2) as OkObjectResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        [Test]
        public void DeleteAMovie_HappyPath_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = DeleteAMovieHappyPathSetup();
            var expected = "Movie was deleted successfully!";

            // Act
            var response = movieController.DeleteAMovie(2) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void DeleteAMovie_DeleteFailure_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = DeleteAMovieDeleteFailureSetup();
            var expected = "Movie failed to be deleted";

            // Act
            var response = movieController.DeleteAMovie(2) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void DeleteAMovie_InvalidId_ReturnsCorrectMessage()
        {
            // Arrange
            var movieController = DeleteAMovieInvalidIdSetup();
            var expected = "Invalid Id was passed.";

            // Act
            var response = movieController.DeleteAMovie(8) as OkObjectResult;
            var actual = response.Value as MovieApiResponse;

            // Assert
            Assert.AreEqual(expected, actual.Info);
        }

        [Test]
        public void DeleteAMovie_GivenException_ReturnsCorrectStatusCode()
        {
            // Arrange
            var movieController = DeleteAMovieExceptionSetup();
            var expected = 500;

            // Act
            var actual = movieController.DeleteAMovie(3) as StatusCodeResult;

            // Assert
            Assert.AreEqual(expected, actual.StatusCode);
        }

        #endregion DeleteAMovie Tests
    }
}