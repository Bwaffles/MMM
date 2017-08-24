using Application;
using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Persistance.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : IEntity
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
            this.tableName = tableName;
        }

        internal virtual dynamic Mapping(T item)
        {
            return item;
        }

        public virtual void Add(T item)
        {
            throw new NotImplementedException();
            //using (IDbConnection connection = Connection)
            //{
            //    var parameters = (object)Mapping(item);
            //    connection.Open();
            //    item.Id = connection.Insert<int>(tableName, parameters);
            //}
        }
        
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
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

        public virtual IEnumerable<T> FindAll()
        {
            IEnumerable<T> items = null;

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                items = connection.Query<T>("SELECT * FROM " + tableName);
            }

            return items;
        }

        //TODO: no nulls-- look into optional object
        public virtual T FindByID(int id)
        {
            T item = default(T);

            using (IDbConnection connection = Connection)
            {
                connection.Open();
                item = connection.Query<T>("SELECT * FROM " + tableName + " WHERE Id=@Id", new { Id = id }).SingleOrDefault();
            }

            return item;
        }

        public virtual void Remove(T item)
        {
            throw new NotImplementedException();
            //using (IDbConnection connection = Connection)
            //{
            //    connection.Open();
            //    connection.Execute("DELETE FROM " + tableName + " WHERE Id=@Id", new { Id = item.Id });
            //}
        }

        public virtual void Update(T item)
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
