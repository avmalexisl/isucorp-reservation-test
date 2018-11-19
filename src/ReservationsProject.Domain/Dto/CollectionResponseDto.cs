using System.Collections.Generic;

namespace ISUCorp.ReservationsProject.Domain.Dto
{
    public class CollectionResponseDto<T>
    {
        public CollectionResponseDto()
        {
            this.Items = new List<T>();
        }

        public int SourceTotal { get; set; }

        public List<T> Items { get; }
    }
}