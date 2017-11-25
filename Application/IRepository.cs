using Domain;
using System.Collections.Generic;

namespace Application
{
    public interface IRepository<T> where T : IEntity
    {
        void Add(T item);

        IEnumerable<T> FindAll();

        T FindByID(int id);

        void Remove(T item);

        void Update(T item);
    }
}