using Application.Movies;
using Application.Movies.Queries.GetMovieDetails;
using Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Application.UnitTests.Movies.Queries.GetMovieDetails
{
    [TestClass]
    public class GetMovieDetailsQueryTests
    {
        [TestClass]
        public class ExecuteTests
        {
            Mock<IMovieRepository> Repository;
            GetMovieDetailsQuery Target;
            TestMovie TestMovie;

            [TestInitialize]
            public void BeforeEachTest()
            {
                TestMovie = new TestMovie();

                Repository = new Mock<IMovieRepository>();
                Repository.Setup(repo => repo.FindByID(It.IsAny<int>())).Returns(TestMovie.Movie);

                Target = new GetMovieDetailsQuery(Repository.Object);
            }

            [TestMethod]
            public void MovieDoesNotExist_ReturnsNull()
            {
                Repository.Setup(repo => repo.FindByID(It.IsAny<int>())).Returns((Movie)null);
                Execute().Should().BeNull();
            }

            [TestMethod]
            public void MovieExists_ReturnsPopulatedItem()
            {
                var actual = Execute();

                actual.Budget.Should().Be(TestMovie.Budget);
                actual.Genres.Should().Be("1, 2");
                actual.Overview.Should().Be(TestMovie.Overview);
                actual.PosterPath.Should().Be(TestMovie.PosterPath);
                actual.ReleaseDate.Should().Be(TestMovie.ReleaseDate);
                actual.Revenue.Should().Be(TestMovie.Revenue);
                actual.Runtime.Should().Be(TestMovie.Runtime);
                actual.Status.Should().Be(TestMovie.Status);
                actual.Tagline.Should().Be(TestMovie.Tagline);
                actual.Title.Should().Be($"{TestMovie.Title} ({TestMovie.ReleaseDate?.Year})");
                actual.Languages.Should().Be("English (original), Spanish");
                actual.ProductionCountries.Should().Be("United States, Canada");
            }

            [TestMethod]
            public void MovieWithNoGenres_GenreIsAnEmptyString()
            {
                TestMovie.Movie.Genres = new List<Genre>();
                Execute().Genres.Should().Be(string.Empty);
            }

            [TestMethod]
            public void MovieWithNoReleaseDate_TitleHasBracketsWithEmptyStringInside()
            {
                TestMovie.Movie.ReleaseDate = null;
                Execute().Title.Should().Be($"{TestMovie.Title} ()");
            }

            private MovieDetailsModel Execute()
            {
                return Target.Execute(1);
            }
        }
    }
}
