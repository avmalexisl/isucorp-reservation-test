using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ISUCorp.ReservationsProject.Core.Entities;
using ISUCorp.ReservationsProject.DataAccess.Interfaces;
using ISUCorp.ReservationsProject.Domain.Dto;
using ISUCorp.ReservationsProject.Domain.Utils;

namespace ISUCorp.ReservationsProject.Domain.Services
{
    public class ReservationDomainService : IReservationDomainService
    {
        private readonly IRepository<Reservation> _repository;

        private readonly IUnitOfWork _unitOfWork;

        public ReservationDomainService(IUnitOfWork unitOfWork)
        {
            MapperCreator.Init();

            this._unitOfWork = unitOfWork;
            this._repository = unitOfWork.Reservations;
        }

        public ReservationDto Add(ReservationInputDto input)
        {
            this._repository.Add(Mapper.Map<Reservation>(input));
            this._unitOfWork.SaveChanges();
            return Mapper.Map<ReservationDto>(input);
        }

        public void Remove(int id)
        {
            var found = this.ValidateReservationExists(id);
            this._repository.Remove(found);
            this._unitOfWork.SaveChanges();
        }

        public ReservationDto Find(int id)
        {
            return Mapper.Map<ReservationDto>(this._repository.FindById(id));
        }

        public CollectionResponseDto<ReservationDto> FindAll(PaginationInputDto input)
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
            var propertyInfo = typeof(Reservation).GetProperty(input.SortBy);
            var result = entities.AsEnumerable().OrderBy(t => propertyInfo.GetValue(t, null)).Skip(input.SkipCount).Take(input.MaxCount).ToList();
            var response = new CollectionResponseDto<ReservationDto> { SourceTotal = entities.Count() };
            var items = Mapper.Map<List<ReservationDto>>(result);
            response.Items.AddRange(items);
            return response;
        }

        public ReservationDto Update(ReservationDto input)
        {
            var found = this.ValidateReservationExists(input.Id);

            found.ReservationDate = input.ReservationDate;
            found.Rating = input.Rating;
            found.IsFavorite = input.IsFavorite;

            this._unitOfWork.SaveChanges();
            return null;
        }

        private Reservation ValidateReservationExists(int id)
        {
            var found = this._repository.FindById(id);
            if (found != null)
            {
                return found;
            }

            var message = string.Format("Sorry, this Reservation does not exist", id);
            throw new Exception(message);
        }
    }
}
