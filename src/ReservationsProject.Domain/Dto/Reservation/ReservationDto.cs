using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace ISUCorp.ReservationsProject.Domain.Dto
{
    public class ReservationDto
    {
        private DateTime _reservationDate;
        public int Id { get; set; }

        public DateTime ReservationDate
        {
            get => _reservationDate;
            set
            {
                FormattedReservationDate = value.ToString("yyyy-MM-dd");
                _reservationDate = value;
            }
        }

        public string FormattedReservationDate { get; private set; }

        public int Rating { get; set; }

        public bool IsFavorite { get; set; }

        public int ContactId { get; set; }

        public virtual ContactDto Contact { get; set; }
    }
}