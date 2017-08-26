using System.ComponentModel.DataAnnotations;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class MovieDetailsModel
    {
        [Display(Name = "Cost")]
        public string Budget { get; set; }

        public string Genres { get; set; }

        [Display(Name = "Spoken Languages")]
        public string Languages { get; set; }

        public string Overview { get; set; }
        public string PosterPath { get; set; }

        [Display(Name = "Produced In")]
        public string ProductionCountries { get; set; }

        [Display(Name = "Released On")]
        public string ReleaseDate { get; set; }

        [Display(Name = "Earned")]
        public string Revenue { get; set; }

        public string Runtime { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
    }
}