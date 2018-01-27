namespace Application.Movies.Queries.GetMoviesList
{
    public class MoviesListItemModel
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public int WatchCount { get; set; }
    }
}