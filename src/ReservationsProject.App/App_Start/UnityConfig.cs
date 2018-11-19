using System.Web.Mvc;
using ISUCorp.ReservationsProject.App.Utils;
using ISUCorp.ReservationsProject.DataAccess.Custom;
using ISUCorp.ReservationsProject.DataAccess.Interfaces;
using ISUCorp.ReservationsProject.Domain.Services;
using Microsoft.Practices.Unity;

namespace ISUCorp.ReservationsProject.App
{
    public class UnityConfig
    {
        public static void ConfigureUnity()
        {
            AppUnityContainer.Container.RegisterType<IUnitOfWork, SQLUnitOfWork>();
            AppUnityContainer.Container.RegisterType<IContactDomainService, ContactDomainService>();
            AppUnityContainer.Container.RegisterType<IReservationDomainService, ReservationDomainService>();

            DependencyResolver.SetResolver(new UnityResolver(AppUnityContainer.Container));
        }
    }
}