using System;
using System.Collections.Generic;
using ISUCorp.ReservationsProject.Core.Entities;
using ISUCorp.ReservationsProject.DataAccess.Interfaces;
using ISUCorp.ReservationsProject.Domain.Dto;
using AutoMapper;
using System.Linq;
using ISUCorp.ReservationsProject.Domain.Utils;

namespace ISUCorp.ReservationsProject.Domain.Services
{
    public class ContactDomainService : IContactDomainService
    {
        private readonly IRepository<Contact> _repository;

        private readonly IUnitOfWork _unitOfWork;

        public ContactDomainService(IUnitOfWork unitOfWork)
        {
            MapperCreator.Init();

            this._unitOfWork = unitOfWork;
            this._repository = unitOfWork.Contacts;
        }

        public ContactDto Add(ContactInputDto input)
        {
            var contact = Mapper.Map<Contact>(input);
            this._repository.Add(contact);
            this._unitOfWork.SaveChanges();
            var dto = Mapper.Map<ContactDto>(contact);
            return dto;
        }

        public void Remove(int id)
        {
            var found = this.ValidateContactExists(id);
            this._repository.Remove(found);
            this._unitOfWork.SaveChanges();
        }

        public ContactDto Find(int id)
        {
            return Mapper.Map<ContactDto>(this._repository.FindById(id));
        }

        public CollectionResponseDto<ContactDto> FindAll()
        {
            var entities = this._repository.FindAll();
            var response = new CollectionResponseDto<ContactDto> { SourceTotal = entities.Count() };
            var items = Mapper.Map<List<ContactDto>>(entities);
            response.Items.AddRange(items);
            return response;
        }

        public CollectionResponseDto<ContactDto> FindAll(PaginationInputDto input)
        {
            if (input.SkipCount < 0)
            {
                input.SkipCount = 0;
            }

            if (input.MaxCount < 0)
            {
                input.MaxCount = 0;
            }

            var entities = this._repository.FindAll();
            var propertyInfo = typeof(Contact).GetProperty(input.SortBy);
            var result = entities.AsEnumerable().OrderBy(t => propertyInfo.GetValue(t, null)).Skip(input.SkipCount).Take(input.MaxCount).ToList();
            var response = new CollectionResponseDto<ContactDto> { SourceTotal = entities.Count() };
            var items = Mapper.Map<List<ContactDto>>(result);
            response.Items.AddRange(items);
            return response;
        }

        public ContactDto Update(ContactDto input)
        {
            var found = this.ValidateContactExists(input.Id);

            found.Name = input.Name;
            found.BirthDate = input.BirthDate;
            found.Type = input.Type;
            found.Phone = input.Phone;
            found.Description = input.Description;

            this._unitOfWork.SaveChanges();
            return null;
        }

        private Contact ValidateContactExists(int id)
        {
            var found = this._repository.FindById(id);
            if (found != null)
            {
                return found;
            }

            var message = string.Format("Sorry, this contact does not exist", id);
            throw new Exception(message);
        }
    }
}