using ISUCorp.ReservationsProject.Core.Interfaces;
using ISUCorp.ReservationsProject.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace ISUCorp.ReservationsProject.DataAccess.Custom
{
    public class SQLRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        protected ObjectSet<T> _objectSet;
        protected ObjectContext _context;

        public SQLRepository(ObjectContext context) {
            _objectSet = context.CreateObjectSet<T>();
            _context = context;
        }

        public void Add(T newEntity)
        {
            _objectSet.AddObject(newEntity);
        }

        public void Remove(T entity)
        {
            _objectSet.DeleteObject(entity);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _objectSet.Where(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return _objectSet;
        }

        public T FindById(int id)
        {
            return _objectSet.Single(o => o.Id == id);
        }

        public T FindByIdStoredProcedure(int id)
        {
            SqlParameter contactId = new SqlParameter("@ContactId", id);
            var contact = _context.ExecuteStoreQuery<T>("GetContact @ContactId", contactId);
            return contact.First();
        }
    }
}
