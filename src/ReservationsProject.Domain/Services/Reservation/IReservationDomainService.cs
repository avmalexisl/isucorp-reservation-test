using ISUCorp.ReservationsProject.Domain.Dto;

namespace ISUCorp.ReservationsProject.Domain.Services
{
    public interface IReservationDomainService
    {
        ReservationDto Add(ReservationInputDto input);

        void Remove(int id);

        ReservationDto Find(int id);

        CollectionResponseDto<ReservationDto> FindAll(PaginationInputDto input);

        ReservationDto Update(ReservationDto input);
    }
}
