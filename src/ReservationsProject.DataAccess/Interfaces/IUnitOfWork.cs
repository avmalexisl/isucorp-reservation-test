using System;
using ISUCorp.ReservationsProject.Core.Entities;

namespace ISUCorp.ReservationsProject.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Contact> Contacts { get; }

        IRepository<Reservation> Reservations { get; }

        void SaveChanges();
    }
}