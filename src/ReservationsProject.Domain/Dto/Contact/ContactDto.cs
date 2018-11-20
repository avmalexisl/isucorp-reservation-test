using System;
using ISUCorp.ReservationsProject.Core;

namespace ISUCorp.ReservationsProject.Domain.Dto
{
    public class ContactDto
    {
        private DateTime _birthDate;
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                FormattedBirthDate = value.ToString("yyyy-MM-dd");
                _birthDate = value;
            }
        }

        public string FormattedBirthDate { get; private set; }

        public ContactType Type { get; set; }

        public string Description { get; set; }
    }
}
