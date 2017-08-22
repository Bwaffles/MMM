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

            return new MovieDetailsModel()
            {
                Budget = movie.Budget,
                Overview = movie.Overview,
                PosterPath = movie.PosterPath,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                Runtime = movie.Runtime,
                Status = movie.Status,
                Tagline = movie.Tagline,
                Title = $"{movie.Title} ({movie.ReleaseDate?.Year})",
            };
        }
    }
}
