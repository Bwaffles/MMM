using Domain;
using System;
using System.Collections.Generic;

namespace Application.UnitTests.Movies.Queries
{
    public class TestMovie
    {
        public readonly long Budget = 10000;
        public readonly int Id = 1;
        public readonly string Overview = "My overview";
        public readonly string PosterPath = "/myPath.jpg";
        public readonly IEnumerable<Country> ProductionCountries = new List<Country>() { new Country() { Id = 1, Code = "US" }, new Country() { Id = 2, Code = "CA" } };
        public readonly DateTime? ReleaseDate = new DateTime(2000, 1, 1);
        public readonly long Revenue = 5000;
        public readonly int? Runtime = 123;
        public readonly IEnumerable<MovieLanguage> SpokenLanguages = new List<MovieLanguage>() { new MovieLanguage() { Code = "en", OriginalLanguage = true }, new MovieLanguage() { Code = "es" } };
        public readonly string Status = "Released";
        public readonly string Tagline = "My tagline";
        public readonly string Title = "My Title";
        public Movie Movie { get; }

        public TestMovie()
        {
            Movie = new Movie()
            {
                Id = Id,
                Budget = Budget,
                Overview = Overview,
                PosterPath = PosterPath,
                ReleaseDate = ReleaseDate,
                Revenue = Revenue,
                Runtime = Runtime,
                Status = Status,
                Tagline = Tagline,
                Title = Title,
                Genres = new List<Genre>() { new Genre() { Name = "1" }, new Genre() { Name = "2" } },
                SpokenLanguages = SpokenLanguages,
                ProductionCountries = ProductionCountries
            };
        }
    }
}