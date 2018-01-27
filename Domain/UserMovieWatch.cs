using System;

namespace Domain
{
    public class UserMovieWatch : IEntity
    {
        public DateTime? Date { get; set; }
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int Number { get; set; }
        public int UserId { get; set; }
    }
}