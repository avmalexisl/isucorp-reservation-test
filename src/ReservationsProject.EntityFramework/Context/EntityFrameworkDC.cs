using System.Data.Entity;
using ISUCorp.ReservationsProject.Core.Entities;

namespace ISUCorp.ReservationsProject.EntityFramework.Context
{
    public class EntityFrameworkDC : DbContext
    {                
        public EntityFrameworkDC()
            : base("ReservationsDB")
        {
        }
                       
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
                
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove();
        }

    }
}