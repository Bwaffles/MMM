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
            private Mock<IMovieRepository> Repository;
            private GetMovieDetailsQuery Target;
            private TestMovie TestMovie;

            [TestInitialize]
            public void BeforeEachTest()
            {
                TestMovie = new TestMovie();

                Repository = new Mock<IMovieRepository>();
                Repository.Setup(repo => repo.FindByID(It.IsAny<int>())).Returns(TestMovie.Movie);

                Target = new GetMovieDetailsQuery(Repository.Object);
            }

            [TestMethod]
            public void GenresIsEmpty_ReturnsGenresAsAnEmptyString()
            {
                TestMovie.Movie.Genres = new List<Genre>();
                Execute().Genres.Should().Be(string.Empty);
            }

            [TestMethod]
            public void GenresIsNotEmpty_ReturnsGenresAsCommaDelimitedList()
            {
                Execute().Genres.Should().Be("1, 2");
            }

            [TestMethod]
            public void MovieDoesNotExist_ReturnsNull()
            {
                Repository.Setup(repo => repo.FindByID(It.IsAny<int>())).Returns((Movie)null);
                Execute().Should().BeNull();
            }

            [TestMethod]
            public void MovieExists_BudgetFormattedAsMonetaryValue()
            {
                Execute().Budget.Should().Be("$10,000");
            }

            [TestMethod]
            public void MovieExists_ReturnsPopulatedItem()
            {
                var actual = Execute();

                actual.Overview.Should().Be(TestMovie.Overview);
                actual.PosterPath.Should().Be(TestMovie.PosterPath);
                actual.Status.Should().Be(TestMovie.Status);
                actual.Tagline.Should().Be(TestMovie.Tagline);
                actual.Title.Should().Be($"{TestMovie.Title} ({TestMovie.ReleaseDate?.Year})");
                actual.Languages.Should().Be("English (original), Spanish");
                actual.ProductionCountries.Should().Be("United States, Canada");
            }

            [TestMethod]
            public void ReleaseDateIsNotNull_ReturnsFormattedReleaseDateString()
            {
                Execute().ReleaseDate.Should().Be("January 01, 2000");
            }

            [TestMethod]
            public void ReleaseDateIsNull_ReturnsTitleWithBracketsWithEmptyStringInside()
            {
                TestMovie.Movie.ReleaseDate = null;
                Execute().Title.Should().Be($"{TestMovie.Title} ()");
            }

            [TestMethod]
            public void ReventIsNotNull_ReturnsRevenueFormattedAsMonetaryValue()
            {
                Execute().Revenue.Should().Be("$5,000");
            }

            [TestMethod]
            public void RuntimeIsNotNull_ReturnsRuntimeFormattedAsHoursAndMinutes()
            {
                Execute().Runtime.Should().Be("2hr 3min");
            }

            [TestMethod]
            public void RuntimeIsNull_ReturnsRuntimeAsAnEmptyString()
            {
                TestMovie.Movie.Runtime = null;
                Execute().Runtime.Should().Be("Unknown");
            }

            private MovieDetailsModel Execute()
            {
                return Target.Execute(1);
            }
        }
    }
}