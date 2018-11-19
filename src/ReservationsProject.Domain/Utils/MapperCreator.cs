using System;
using AutoMapper;
using ISUCorp.ReservationsProject.Core.Entities;
using ISUCorp.ReservationsProject.Domain.Dto;

namespace ISUCorp.ReservationsProject.Domain.Utils
{
    public static class MapperCreator
    {
        public static void Init()
        {
            try
            {
                var mapperInstance = Mapper.Instance;
            }
            catch (InvalidOperationException)
            {
                // Mapper is not initialized, so do it.
                Mapper.Initialize(cfg =>
                {
                    // Contact entities
                    cfg.CreateMap<ContactInputDto, Contact>();
                    cfg.CreateMap<Contact, ContactDto>();

                    // Reservation entities
                    cfg.CreateMap<ReservationInputDto, ReservationDto>();
                    cfg.CreateMap<ReservationDto, ReservationInputDto>();
                    cfg.CreateMap<ReservationInputDto, Reservation>();
                    cfg.CreateMap<Reservation, ReservationDto>();
                });
            }
        }
    }
}
