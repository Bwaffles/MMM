using Domain;
using Mapster;
using System.Globalization;
using System.Linq;
using System;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class GetMovieDetailsQuery : IGetMovieDetailsQuery
    {
        private IMovieRepository movieRepository;

        public GetMovieDetailsQuery(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public MovieDetailsModel Execute(int id)
        {
            var movie = movieRepository.FindByID(id);
            if (movie == null)
                return null;

            TypeAdapterConfig<Movie, MovieDetailsModel>
                .NewConfig()
                .Map(dest => dest.Budget, src => src.Budget.ToString("C0"))
                .Map(dest => dest.Revenue, src => src.Revenue.ToString("C0"))
                .Map(dest => dest.Runtime, src => FormatRuntime(src))
                .Map(dest => dest.ReleaseDate, src => FormatReleaseDate(src))
                .Map(dest => dest.Title,
                     src => string.Format("{0} ({1})", src.Title, (src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year.ToString() : string.Empty)))
                .Map(dest => dest.Languages, src => FormatLanguages(src))
                .Map(dest => dest.Genres, src => string.Join(", ", src.Genres.Select(genre => genre.Name)))
                .Map(dest => dest.ProductionCountries, src => string.Join(", ", src.ProductionCountries.Select(country => new RegionInfo(country.Code).DisplayName)));

            return movie.Adapt<MovieDetailsModel>();
        }

        private string FormatLanguages(Movie movie)
        {
            var languages = movie.SpokenLanguages.Select(language =>
            {
                var name = language.Name;
                if (language.OriginalLanguage)
                    name += " (original)";
                return name;
            });
            return string.Join(", ", languages);
        }

        private string FormatReleaseDate(Movie src)
        {
            if (!src.ReleaseDate.HasValue)
                return string.Empty;

            return src.ReleaseDate.Value.ToString("MMMM dd, yyyy");
        }

        private string FormatRuntime(Movie src)
        {
            if (!src.Runtime.HasValue)
                return "Unknown";

            var time = TimeSpan.FromMinutes(src.Runtime.Value);
            return $"{time.Hours}hr {time.Minutes}min";
        }
    }
}