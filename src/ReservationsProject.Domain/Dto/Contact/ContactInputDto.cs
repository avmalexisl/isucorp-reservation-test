using System;
using ISUCorp.ReservationsProject.Core;

namespace ISUCorp.ReservationsProject.Domain.Dto
{
    public class ContactInputDto
    {
        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate { get; set; }

        public ContactType Type { get; set; }

        public string Description { get; set; }
    }
}