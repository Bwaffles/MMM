using Application.Movies;
using Application.Movies.Queries.GetMoviesList;
using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.TMDb;
using System.Collections.Generic;
using System.Linq;

namespace Application.UnitTests.Movies.Queries.GetMoviesList
{
    [TestClass]
    public class GetMoviesListQueryTests
    {
        private Mock<IMovieRepository> Repository;
        private GetMoviesListQuery Target;
        private MovieTestData TestMovie;
        private Mock<ITMDbService> TMDbService;
        private int UserId = 1;

        [TestInitialize]
        public void BeforeEachTest()
        {
            TestMovie = new MovieTestData();

            Repository = new Mock<IMovieRepository>();
            Repository.Setup(repo => repo.FindAllByUser(UserId)).Returns(new List<Movie> { TestMovie.Movie });

            TMDbService = new Mock<ITMDbService>();

            Target = new GetMoviesListQuery(Repository.Object, TMDbService.Object);
        }

        [TestMethod]
        public void MovieExists_PosterUrlShouldBeSetToGetImagePathResult()
        {
            TMDbService.Setup(service => service.GetImagePath(It.IsAny<string>(), TestMovie.PosterPath)).Returns(TestMovie.PosterPath);

            var actual = Execute().First();
            actual.PosterUrl.Should().Be(TestMovie.PosterPath);
        }

        [TestMethod]
        public void MovieExists_ReturnsPopulatedItem()
        {
            var actual = Execute().First();

            actual.Id.Should().Be(TestMovie.Id);
            actual.Tagline.Should().Be(TestMovie.Tagline);
            actual.Title.Should().Be($"{TestMovie.Title} ({TestMovie.ReleaseDate?.Year})");
            actual.WatchCount.Should().Be(TestMovie.WatchCount);
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
            Repository.Setup(repo => repo.FindAllByUser(UserId)).Returns(Enumerable.Empty<Movie>);
            Execute().Should().BeEmpty();
        }

        private IEnumerable<MoviesListItemModel> Execute()
        {
            return Target.Execute(UserId);
        }
    }
}