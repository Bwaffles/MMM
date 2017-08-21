using Application.Movies.Queries.GetMoviesList;
using System.Web.Mvc;

namespace Presentation.Movie
{
    [RoutePrefix("movies")]
    public class MoviesController : Controller
    {
        IGetMoviesListQuery moviesListQuery;

        public MoviesController(IGetMoviesListQuery moviesListQuery)
        {
            this.moviesListQuery = moviesListQuery;
        }

        // GET: Movie
        [Route("")]
        public ActionResult Index()
        {
            return View(moviesListQuery.Execute());
        }

        // GET: Movie/Details/5
        [Route("{id:int}")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Movie/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Movie/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Movie/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
