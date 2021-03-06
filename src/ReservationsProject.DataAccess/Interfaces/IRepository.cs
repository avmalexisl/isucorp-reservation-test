﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ISUCorp.ReservationsProject.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T newEntity);

        void Remove(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        IEnumerable<T> FindAll();

        T FindById(int id);

        T FindByIdStoredProcedure(int id);
    }
}
