using System;
using System.ComponentModel.DataAnnotations;

namespace ISUCorp.ReservationsProject.Core.Entities
{
    public class Reservation : BaseEntity
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        public int Rating { get; set; }

        public bool IsFavorite { get; set; }

        public int ContactId { get; set; }

        public virtual Contact Contact { get; set; }
    }
}
