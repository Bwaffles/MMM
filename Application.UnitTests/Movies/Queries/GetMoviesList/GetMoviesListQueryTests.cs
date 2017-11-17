using Application.Movies;
using Application.Movies.Queries.GetMoviesList;
using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Application.UnitTests.Movies.Queries.GetMoviesList
{
    [TestClass]
    public class GetMoviesListQueryTests
    {
        private Mock<IMovieRepository> Repository;
        private GetMoviesListQuery Target;
        private TestMovie TestMovie;

        [TestInitialize]
        public void BeforeEachTest()
        {
            TestMovie = new TestMovie();

            Repository = new Mock<IMovieRepository>();
            Repository.Setup(repo => repo.FindAll()).Returns(new List<Movie> { TestMovie.Movie });

            Target = new GetMoviesListQuery(Repository.Object);
        }

        [TestMethod]
        public void MovieExists_ReturnsPopulatedItem()
        {
            var actual = Execute().First();

            actual.Id.Should().Be(TestMovie.Id);
            actual.Tagline.Should().Be(TestMovie.Tagline);
            actual.Title.Should().Be($"{TestMovie.Title} ({TestMovie.ReleaseDate?.Year})");
        }

        [TestMethod]
        public void MovieWithNoReleaseDate_TitleHasBracketsWithEmptyStringInside()
        {
            TestMovie.Movie.ReleaseDate = null;
            Execute().First().Title.Should().Be($"{TestMovie.Title} ()");
        }

        [TestMethod]
        public void NoMoviesExist_ReturnsEmptyEnumerable()
        {
            Repository.Setup(repo => repo.FindAll()).Returns(new List<Movie>());
            Execute().Should().BeEmpty();
        }

        private IEnumerable<MoviesListItemModel> Execute()
        {
            return Target.Execute();
        }
    }
}