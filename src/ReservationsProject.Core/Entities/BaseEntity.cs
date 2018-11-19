using ISUCorp.ReservationsProject.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ISUCorp.ReservationsProject.Core.Entities
{
    public class BaseEntity : IEntity
    {
        [Required]
        public int Id { get; set; }
    }
}
