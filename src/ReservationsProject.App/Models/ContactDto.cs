using System.ComponentModel.DataAnnotations;
using ISUCorp.ReservationsProject.Core;

namespace ISUCorp.ReservationsProject.App.Models
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Birthdate { get; set; }

        public ContactType Type { get; set; }

        public string Phone { get; set; }

        public string Description { get; set; }
    }
}