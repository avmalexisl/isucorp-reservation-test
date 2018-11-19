using ISUCorp.ReservationsProject.Core.Utils;

namespace ISUCorp.ReservationsProject.Core
{
    public enum ContactType
    {
        [LocalizedDescription("Basic", typeof(Localization))]
        Basic = 0,

        [LocalizedDescription("Medium", typeof(Localization))]
        Medium = 1,

        [LocalizedDescription("Advanced", typeof(Localization))]
        Advanced = 2
    }
}
