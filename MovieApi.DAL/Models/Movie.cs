using System;
using System.Collections.Generic;

#nullable disable

namespace MovieApi.DAL.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Plot { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Duration { get; set; }
        public string MpaaRating { get; set; }
        public int ReleaseYear { get; set; }
    }
}
