using static MovieApi.UnitTests.Helpers.FakeMovieDb;
using static MovieApi.UnitTests.Helpers.Repo;
using NUnit.Framework;

namespace MovieApi.UnitTests
{
    [TestFixture]
    public class MovieRepoTests
    {
        #region GetAll Tests

        [Test]
        public void GetAll_NoParams_ReturnsCorrectNoOfMovies()
        {
            // Arrange
            var movieRepo = SetupForGetOperations();
            var expected = 3;

            // Act
            var actual = movieRepo.GetAll();

            // Assert
            Assert.AreEqual(expected, actual.Count);
        }

        #endregion GetAll Tests

        #region GetMovieById Tests

        [Test]
        public void GetMovieById_ValidId_ReturnsCorrectMovie()
        {
            // Arrange
            var movieRepo = SetupForGetOperations();
            var expected = "Indiana Jones";

            // Act
            var actual = movieRepo.GetMovieById(2);

            // Assert
            Assert.AreEqual(expected, actual.Title);
        }

        #endregion GetMovieById Tests

        #region CreateAMovie Tests

        [Test]
        public void CreateAMovie_GivenMovie_ReturnsTrue()
        {
            // Arrange
            var movieRepo = HappyPathSetupForWriteOperations();
            var expected = true;

            // Act
            var actual = movieRepo.CreateAMovie(ReturnMovie());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateAMovie_NullMovie_ReturnsFalse()
        {
            // Arrange
            var movieRepo = SadPathSetupForWriteOperations();
            var expected = false;

            // Act
            var actual = movieRepo.CreateAMovie(null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion CreateAMovie Tests

        #region UpdateAMovie Tests

        [Test]
        public void UpdateAMovie_GivenMovie_ReturnsTrue()
        {
            // Arrange
            var movieRepo = HappyPathSetupForWriteOperations();
            var expected = true;

            // Act
            var actual = movieRepo.UpdateAMovie(ReturnMovie());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UpdateAMovie_NullMovie_ReturnsFalse()
        {
            // Arrange
            var movieRepo = SadPathSetupForWriteOperations();
            var expected = false;

            // Act
            var actual = movieRepo.UpdateAMovie(null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion UpdateAMovie Tests

        #region DeleteAMovie Tests

        [Test]
        public void DeleteAMovie_GivenMovie_ReturnsTrue()
        {
            // Arrange
            var movieRepo = HappyPathSetupForWriteOperations();
            var expected = true;

            // Act
            var actual = movieRepo.DeleteAMovie(ReturnMovie());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DeleteAMovie_NullMovie_ReturnsFalse()
        {
            // Arrange
            var movieRepo = SadPathSetupForWriteOperations();
            var expected = false;

            // Act
            var actual = movieRepo.DeleteAMovie(null);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion DeleteAMovie Tests

        #region GetLastMovieId Tests

        [Test]
        public void GetLastMovieId_NoParams_ReturnsCorrectId()
        {
            // Arrange
            var movieRepo = SetupForGetOperations();
            var expected = 3;

            // Act
            var actual = movieRepo.GetLastMovieId();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion GetLastMovieId Tests

        #region MovieExists Tests

        [Test]
        public void MovieExists_GivenSameMovie_ReturnsTrue()
        {
            // Arrange
            var movieRepo = SetupForGetOperations();
            var expected = true;

            // Act
            var actual = movieRepo.MovieExists(ReturnMovie());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MovieExists_GivenDiffMovie_ReturnsFalse()
        {
            // Arrange
            var movieRepo = SetupForGetOperations();
            var expected = false;

            // Act
            var actual = movieRepo.MovieExists(ReturnDiffMovie());

            // Assert
            Assert.AreEqual(expected, actual);
        }

        #endregion MovieExists Tests
    }
}
