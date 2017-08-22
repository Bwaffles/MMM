namespace Application.Movies.Queries.GetMovieDetails
{
    public interface IGetMovieDetailsQuery
    {
        MovieDetailsModel Execute(int id);
    }
}
