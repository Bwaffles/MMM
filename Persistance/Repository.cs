using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;
using Domain;

namespace Persistance.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly string tableName;

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        public Repository(string tableName)
        {
            this.tableName = tableName;
        }

        internal virtual dynamic Mapping(T item)
        {
            return item;
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
            //using (IDbConnection connection = Connection)
            //{
            //    var parameters = (object)Mapping(item);
            //    connection.Open();
            //    item.Id = connection.Insert<int>(tableName, parameters);
            //}
        }
        
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
            //IEnumerable<T> items = null;

            //// extract the dynamic sql query and parameters from predicate
            //QueryResult result = DynamicQuery.GetDynamicQuery(tableName, predicate);

            //using (IDbConnection connection = Connection)
            //{
            //    connection.Open();
            //    items = connection.Query<T>(result.Sql, (object)result.Param);
            //}

            //return items;
        }

        public IEnumerable<T> FindAll()
        {
            IEnumerable<T> items = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                items = connection.Query<T>("SELECT * FROM " + tableName);
            }

            return items;
        }

        public T FindByID(Guid id)
        {
            throw new NotImplementedException();
            //T item = default(T);

            //using (IDbConnection connection = Connection)
            //{
            //    connection.Open();
            //    item = connection.Query<T>("SELECT * FROM " + tableName + " WHERE Id=@Id", new { Id = id }).SingleOrDefault();
            //}

            //return item;
        }

        public void Remove(T item)
        {
            throw new NotImplementedException();
            //using (IDbConnection connection = Connection)
            //{
            //    connection.Open();
            //    connection.Execute("DELETE FROM " + tableName + " WHERE Id=@Id", new { Id = item.Id });
            //}
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
            //using (IDbConnection connection = Connection)
            //{
            //    var parameters = (object)Mapping(item);
            //    connection.Open();
            //    connection.Update(tableName, parameters);
            //}
        }
    }
}
