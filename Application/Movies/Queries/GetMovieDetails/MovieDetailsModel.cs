using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class MovieDetailsModel
    {
        public long Budget { get; set; }
        public string Genres { get; set; }
        [Display(Name="Spoken Languages")]
        public string Languages { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long Revenue { get; set; }
        public int? Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
    }
}
