using ISUCorp.ReservationsProject.Domain.Dto;

namespace ISUCorp.ReservationsProject.Domain.Services
{
    public interface IContactDomainService
    {
        ContactDto Add(ContactInputDto input);

        void Remove(int id);

        ContactDto Find(int id);

        CollectionResponseDto<ContactDto> FindAll(PaginationInputDto input);

        ContactDto Update(ContactDto input);
    }
}