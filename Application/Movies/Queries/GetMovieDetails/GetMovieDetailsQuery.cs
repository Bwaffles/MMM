using Domain;
using Mapster;
using System.Globalization;
using System.Linq;

namespace Application.Movies.Queries.GetMovieDetails
{
    public class GetMovieDetailsQuery : IGetMovieDetailsQuery
    {
        IMovieRepository movieRepository;

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
                .Map(dest => dest.Title, 
                     src => string.Format("{0} ({1})", src.Title, (src.ReleaseDate.HasValue ? src.ReleaseDate.Value.Year.ToString() : string.Empty)))
                .Map(dest => dest.Languages, src => string.Join(", ", src.SpokenLanguages.Select(language => CultureInfo.GetCultureInfo(language.Code).DisplayName)))
                .Map(dest => dest.Genres, src => string.Join(", ", src.Genres.Select(genre => genre.Name)))
                .Map(dest => dest.ProductionCountries, src => string.Join(", ", src.ProductionCountries.Select(country => new RegionInfo(country.Code).DisplayName)));

            return movie.Adapt<MovieDetailsModel>();
        }
    }
}
