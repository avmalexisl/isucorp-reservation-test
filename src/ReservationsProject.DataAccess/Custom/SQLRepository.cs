using ISUCorp.ReservationsProject.Core.Interfaces;
using ISUCorp.ReservationsProject.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISUCorp.ReservationsProject.DataAccess.Custom
{
    public class SQLRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected ObjectSet<T> _objectSet;

        public SQLRepository(ObjectContext context) {
            _objectSet = context.CreateObjectSet<T>();
        }

        public void Add(T newEntity)
        {
            _objectSet.AddObject(newEntity);
        }

        public void Remove(T entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }

        public IQueryable<T> FindAll()
        {
            return _objectSet;
        }

        public T FindById(int id)
        {
            return _objectSet.Single(o => o.Id == id);
        }
    }
}
