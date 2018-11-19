using System;
using System.Linq;
using System.Linq.Expressions;

namespace ISUCorp.ReservationsProject.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T newEntity);

        void Remove(T entity);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindAll();

        T FindById(int id);
    }
}
