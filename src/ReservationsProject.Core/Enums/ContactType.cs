using ISUCorp.ReservationsProject.Core.Utils;

namespace ISUCorp.ReservationsProject.Core
{
    public enum ContactType
    {
        [LocalizedDescription("Basic", typeof(Localization))]
        Basic,

        [LocalizedDescription("Medium", typeof(Localization))]
        Medium,

        [LocalizedDescription("Advanced", typeof(Localization))]
        Advanced
    }
}
