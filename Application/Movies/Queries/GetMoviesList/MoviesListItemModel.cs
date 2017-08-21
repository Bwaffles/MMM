using System;
using System.ComponentModel;

namespace Application.Movies.Queries.GetMoviesList
{
    public class MoviesListItemModel
    {
        public string Title { get; set; }
        public int? ReleaseYear { get; set; }
        public string Tagline { get; set; }
    }
}