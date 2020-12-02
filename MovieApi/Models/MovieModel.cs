using System.Diagnostics.CodeAnalysis;
using System;

namespace MovieApi.Models
{
    [ExcludeFromCodeCoverage]
    public class MovieModel
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Duration { get; set; }
        public string MpaaRating { get; set; }
        public int ReleaseYear { get; set; }
    }
}
