using Application.Movies;
using Dapper;
using Domain;
using Persistance.Repositories;
using Slapper;
using System.Collections.Generic;
using System.Linq;

namespace Persistance
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository() : base("Movie") { }

        public override Movie FindByID(int id)
        {
            Movie item;

            using (var connection = Connection)
            {
                var sql = "SELECT m.*, "
                        + "g.Id as Genres_Id, g.Name as Genres_Name, "
                        + "l.Id as SpokenLanguages_Id, l.Code SpokenLanguages_Code "
                        + $"FROM {tableName} m "
                        + "INNER JOIN MovieGenre mg on mg.MovieId = m.Id "
                        + "INNER JOIN Genre g on g.Id = mg.GenreId "
                        + "INNER JOIN MovieLanguage ml on ml.MovieId = m.Id "
                        + "INNER JOIN Language l on l.Id = ml.LanguageId "
                        + "WHERE m.Id = @Id";

                connection.Open();
                var query = connection.Query(sql, new { Id = id }) as IEnumerable<IDictionary<string, object>>;
                item = AutoMapper.Map<Movie>(query).SingleOrDefault();
            }

            return item;
        }
    }
}
