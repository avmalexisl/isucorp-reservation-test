using System;
using ISUCorp.ReservationsProject.Core;

namespace ISUCorp.ReservationsProject.Domain.Dto
{
    public class ContactDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public ContactType Type { get; set; }

        public string Description { get; set; }

        public string FormattedBirthDate { get; set; }
    }
}
