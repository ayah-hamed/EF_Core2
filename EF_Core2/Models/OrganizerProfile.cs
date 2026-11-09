
namespace EF_Core2
{
    #region OrganizerProfile - Fluent API

    // store the public profile of an organizer
    public class OrganizerProfile
    {
        // primary key
        public int Id { get; set; }

     
        public string? Biography { get; set; }

        // organizer's personal or company website
        public string? Website { get; set; }

    
        public string? Logo { get; set; }

        // foreign key linking the profile to an organizer
        public int OrganizerId { get; set; }

        // navigation property to access the organizer
        public Organizer Organizer { get; set; } = null!;
    }

    #endregion
}
