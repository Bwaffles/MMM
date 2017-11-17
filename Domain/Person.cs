using System;

namespace Domain
{
    public class Person : IEntity
    {
        public string Biography { get; set; }
        public DateTime? Birthday { get; set; }
        public string BirthPlace { get; set; }
        public DateTime? Deathday { get; set; }
        public PersonGender Gender { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string Name { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public int TMDBId { get; set; }
    }
}