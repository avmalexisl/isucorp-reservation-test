using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISUCorp.ReservationsProject.Domain.Dto
{
    public class ReservationInputDto
    {
        public DateTime ReservationDate { get; set; }

        public int Rating { get; set; }

        public bool IsFavorite { get; set; }

        public int ContactId { get; set; }
    }
}
