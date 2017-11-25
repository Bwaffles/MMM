using Application;
using Dapper;
using Dapper.Contrib.Extensions;
using Domain;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Persistance.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly string tableName;

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        public Repository(string tableName)
        {
            this.tableName = $"{tableName}";
        }

        public virtual void Add(TEntity item)
        {
            using (var connection = Connection)
                connection.Insert(item);
        }

        //public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    IEnumerable<TEntity> items = null;
        //    using (var connection = Connection)
        //    {
        //        connection.Open();
        //        var predicate = Predicates.Field<Person>(f => f.Active, Operator.Eq, true);
        //        items = connection.Query<T>(result.Sql, (object)result.Param);

        //        connection.Close();
        //    }
        //    return items;

        //    //IEnumerable<T> items = null;

        //    //// extract the dynamic sql query and parameters from predicate
        //    //QueryResult result = DynamicQuery.GetDynamicQuery(tableName, predicate);

        //    //using (IDbConnection connection = Connection)
        //    //{
        //    //    connection.Open();
        //    //    items = connection.Query<T>(result.Sql, (object)result.Param);
        //    //}

        //    //return items;
        //}

        public virtual IEnumerable<TEntity> FindAll()
        {
            IEnumerable<TEntity> items = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                items = connection.Query<TEntity>("SELECT * FROM " + tableName);
                connection.Close();
            }

            return items;
        }

        //TODO: no nulls-- look into optional object
        public virtual TEntity FindByID(int id)
        {
            TEntity item = default(TEntity);

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                item = connection.Query<TEntity>("SELECT * FROM " + tableName + " WHERE Id=@Id", new { Id = id }).SingleOrDefault();
                connection.Close();
            }

            return item;
        }

        public virtual void Remove(TEntity item)
        {
            using (IDbConnection connection = Connection)
                connection.Delete(item);
        }

        public virtual void Update(TEntity item)
        {
            using (IDbConnection connection = Connection)
                connection.Update(item);
        }
    }
}