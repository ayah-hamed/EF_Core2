
namespace EF_Core2
{
    #region Badge - Fluent API

    // define the available badge tiers
    public enum BadgeTier
    {
        Standard,
        VIP
    }

    // store the badge issued to an attendee
    public class Badge
    {
        // primary key
        public int Id { get; set; }

        // unique number assigned to each badge
        public int BadgeNumber { get; set; }

        // date when the badge was issued
        public DateTime IssuedDate { get; set; }

        // badge tier can be Standard or VIP
        public BadgeTier Tier { get; set; }

        // foreign key linking the badge to an attendee
        public int AttendeeId { get; set; }

        // navigation property to access the attendee
        public Attendee Attendee { get; set; } = null!;
    }

    #endregion
}
