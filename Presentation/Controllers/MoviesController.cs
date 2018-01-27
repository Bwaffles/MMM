using Application.Movies.Queries.GetMovieDetails;
using Application.Movies.Queries.GetMoviesList;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class MoviesController : Controller
    {
        IGetMoviesListQuery moviesListQuery;
        IGetMovieDetailsQuery movieDetailsQuery;

        public MoviesController(IGetMoviesListQuery moviesListQuery, IGetMovieDetailsQuery movieDetailsQuery)
        {
            this.moviesListQuery = moviesListQuery;
            this.movieDetailsQuery = movieDetailsQuery;
        }

        // GET: Movies
        public ActionResult Index()
        {
            //TODO: find a better way to get the user ID since this is supposed to be unit tested
            int temp;
            var userId = int.TryParse(User.Identity.GetUserId(), out temp) ? temp : (int?)null;
            return View(moviesListQuery.Execute(userId));
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            return View(movieDetailsQuery.Execute(id));
        }
    }
}
