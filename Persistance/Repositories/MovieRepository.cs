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
        public MovieRepository() : base("Movie")
        {
        }

        public override Movie FindByID(int id)
        {
            Movie item;

            using (var connection = Connection)
            {
                var sql = "SELECT m.*, "
                        + "g.Id Genres_Id, g.Name Genres_Name, "
                        + "l.Id SpokenLanguages_LanguageId, l.Code SpokenLanguages_Code, ml.OriginalLanguage SpokenLanguages_OriginalLanguage, "
                        + "c.Id ProductionCountries_Id, c.Code ProductionCountries_Code "
                        + $"FROM {tableName} m "
                        + "LEFT JOIN MovieGenre mg on mg.MovieId = m.Id "
                        + "LEFT JOIN Genre g on g.Id = mg.GenreId "
                        + "LEFT JOIN MovieLanguage ml on ml.MovieId = m.Id "
                        + "LEFT JOIN Language l on l.Id = ml.LanguageId "
                        + "LEFT JOIN MovieCountry mc on mc.MovieId = m.Id "
                        + "LEFT JOIN Country c on c.Id = mc.CountryId "
                        + "WHERE m.Id = @Id";

                connection.Open();
                var query = connection.Query(sql, new { Id = id }) as IEnumerable<IDictionary<string, object>>;
                item = AutoMapper.Map<Movie>(query).SingleOrDefault();
            }

            return item;
        }
    }
}