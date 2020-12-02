using System.Diagnostics.CodeAnalysis;
using MovieApi.Models;
using System;

namespace MovieApi.Utils
{
    [ExcludeFromCodeCoverage]
    public static class MovieApiMessenger
    {
        public const string GetAllMoviesEntry = "Entered GetAllMovies api call";
        public const string MoviesReturned = "Successfully returned all movies!";
        public const string MoviesNotFound = "No movies could be found.";
        public const string AddSuccess = "Movie was added successfully!";
        public const string AddFailure = "Movie failed to be added.";
        public const string UpdateSuccess = "Movie was updated successfully!";
        public const string UpdateFailure = "Movie failed to update.";
        public const string DeleteSuccess = "Movie was deleted successfully!";
        public const string DeleteFailure = "Movie failed to be deleted";
        public const string InvalidId = "Invalid Id was passed.";
        public const string AlreadyExists = "That movie already exists in the database.";

        public static string GetMovieByIdEntry(int id)
        {
            return $"Entered GetMovieById api call, input id is {id}.";
        }

        public static string MovieFound(string title)
        {
            return $"{title} found successfully!";
        }

        public static string InvalidIdPassed(string methodName, int id)
        {
            return $"{methodName} was passed an invalid id of {id}.";
        }

        public static string CreateMovieEntry(MovieModel movieModel)
        {
            return $"Entered CreateAMovie api call, the following movie object " +
                $"was passed in:\n" +
                $"Title: {movieModel.Title}\n" +
                $"Plot: {movieModel.Plot}\n" +
                $"Duration: {movieModel.Duration}\n" +
                $"Release Date: {movieModel.ReleaseDate}\n" +
                $"Release Year: {movieModel.ReleaseYear}\n" +
                $"Mpaa Rating: {movieModel.MpaaRating}\n";
        }

        public static string ReturnWriteOperationMessage(bool result,
            string method, string title)
        {
            var message = "";

            if (method.Equals("Create", StringComparison.InvariantCultureIgnoreCase)
                && result == true)
                message = $"{title} was created successfully!";
            else if (method.Equals("Create", StringComparison.InvariantCultureIgnoreCase)
                && result == false)
                message = $"{title} was not created successfully.";
            else if (method.Equals("Update", StringComparison.InvariantCultureIgnoreCase)
                && result == true)
                message = $"{title} was updated successfully!";
            else if (method.Equals("Update", StringComparison.InvariantCultureIgnoreCase)
                && result == false)
                message = $"{title} was not updated successfully.";
            else if (method.Equals("Delete", StringComparison.InvariantCultureIgnoreCase)
                && result == true)
                message = $"{title} was deleted successfully!";
            else if (method.Equals("Delete", StringComparison.InvariantCultureIgnoreCase)
                && result == false)
                message = $"{title} was not deleted successfully.";

            return message;
        }

        public static string ReturnAlreadyExists(string title)
        {
            return $"{title} already exists in the database.";
        }

        public static string UpdateMovieEntry(int id, MovieModel movieModel)
        {
            return $"Entered UpdateAMovie api call, id passed in is {id}." +
                $"The following move object was passed:\n" +
                $"Title:{movieModel.Title}\n" +
                $"Plot: {movieModel.Plot}\n" +
                $"Duration: {movieModel.Duration}\n" +
                $"Release Date: {movieModel.ReleaseDate}\n" +
                $"Release Year: {movieModel.ReleaseYear}\n" +
                $"Mpaa Rating: {movieModel.MpaaRating}\n";
        }

        public static string DeleteMovieEntry(int id)
        {
            return $"Entered DeleteAMovie api call, input id is {id}.";
        }
    }
}
