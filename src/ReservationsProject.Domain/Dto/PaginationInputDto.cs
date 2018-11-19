using System.ComponentModel.DataAnnotations;

namespace ISUCorp.ReservationsProject.Domain.Dto
{
    public class PaginationInputDto
    {
        public PaginationInputDto(int skipCount, int maxCount, string sortBy)
        {
            this.SkipCount = skipCount;
            this.MaxCount = maxCount;
            this.SortBy = sortBy;
        }
        
        [Required]
        public int SkipCount { get; set; }
        
        [Required]
        public int MaxCount { get; set; }
        
        public string SortBy { get; }
    }
}