using Microsoft.Practices.Unity;

namespace ISUCorp.ReservationsProject.App.Utils
{
    public static class AppUnityContainer
    {
        private static UnityContainer _container;

        public static UnityContainer Container => _container ?? (_container = new UnityContainer());
    }
}