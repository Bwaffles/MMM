using Dapper;
using Domain;
using System.Collections.Generic;

namespace Persistance.Repositories
{
    public class GenreRepository : Repository<Genre> //don't plan to use this in the application layer yet so not going to make an interface for it
    {
        public GenreRepository() : base("Genre") { }

        public IEnumerable<Genre> FindByMovieId(int id)
        {
            IEnumerable<Genre> items;

            using (var connection = Connection)
            {
                connection.Open();
                var sql = $@"SELECT g.* from {tableName} g, MovieGenre mg where mg.GenreId = g.Id and mg.MovieId = @Id;";
                items = connection.Query<Genre>(sql, new { Id = id });
            }

            return items;
        }
    }
}
