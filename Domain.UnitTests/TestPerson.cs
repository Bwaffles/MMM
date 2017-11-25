using System;

namespace Domain.UnitTests
{
    public class TestPerson
    {
        public const string Biography = "This is my biography";
        public const string BirthPlace = "City, State, Country";
        public const PersonGender Gender = PersonGender.Male;
        public const string Homepage = "www.homepage.com";
        public const int Id = 1;
        public const string ImdbId = "nm0000012";
        public const string Name = "Tony Guy";
        public const double Popularity = 2.1234567;
        public const string ProfilePath = "/jkl421mkldsan.jpg";
        public const int TMDBId = 1;
        public static readonly DateTime? Birthday = new DateTime(1944, 12, 13);
        public static readonly DateTime? Deathday = new DateTime(2017, 4, 21);
        public Person Person { get; set; }

        public TestPerson()
        {
            Person = new Person
            {
                Biography = Biography,
                Birthday = Birthday,
                BirthPlace = BirthPlace,
                Deathday = Deathday,
                Gender = Gender,
                Homepage = Homepage,
                Id = Id,
                ImdbId = ImdbId,
                Name = Name,
                Popularity = Popularity,
                ProfilePath = ProfilePath,
                TMDBId = TMDBId
            };
        }
    }
}