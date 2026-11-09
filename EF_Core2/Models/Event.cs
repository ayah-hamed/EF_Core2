
namespace EF_Core2
{
    #region Event - Fluent API

    // store information about events
    public class Event
    {
        // primary key
        public int Id { get; set; }

        // name of the event
        public string Title { get; set; } = string.Empty;

        // details about the event
        public string Description { get; set; } = string.Empty;

        // date and time when the event starts
        public DateTime StartDate { get; set; }

        // optional date and time when the event ends
        public DateTime? EndDate { get; set; }

        // maximum number of attendees allowed
        public int MaxAttendees { get; set; }

        // foreign key linking the event to its organizer
        public int OrganizerId { get; set; }

        // navigation property to access the organizer
        public Organizer Organizer { get; set; } = null!;
    }

    #endregion
}
