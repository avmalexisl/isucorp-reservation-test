
using ISUCorp.ReservationsProject.Core.Entities;
using ISUCorp.ReservationsProject.DataAccess.Interfaces;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using ISUCorp.ReservationsProject.EntityFramework.Context;

namespace ISUCorp.ReservationsProject.DataAccess.Custom
{
    public class SQLUnitOfWork : IUnitOfWork
    {
        private ObjectContext Context { get; }

        private IRepository<Contact> _contacts;

        public IRepository<Contact> Contacts =>
            this._contacts ?? (this._contacts = new SQLRepository<Contact>(this.Context));

        private IRepository<Reservation> _reservations;

        public IRepository<Reservation> Reservations =>
            this._reservations ?? (this._reservations = new SQLRepository<Reservation>(this.Context));

        public SQLUnitOfWork()
        {
            var dataContext = new EntityFrameworkDC();
            var adapter = (IObjectContextAdapter)dataContext;
            this.Context = adapter.ObjectContext;
        }

        public void Dispose()
        {
            this.Context?.Dispose();
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

    }
}
