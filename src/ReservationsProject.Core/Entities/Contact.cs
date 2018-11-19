using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISUCorp.ReservationsProject.Core.Entities
{
    public class Contact : BaseEntity
    {
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        public ContactType Type { get; set; }

        public string Description { get; set; }

        public List<Reservation> Reservations { get; set; }

    }
}
