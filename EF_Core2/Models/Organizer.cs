
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core2
{
    #region Organizer - Data Annotations

    // store information about event organizers
    [Table("EventOrganizers")]
    public class Organizer
    {
        // primary key
        public int Id { get; set; }

        // organizer name is required with a maximum of 100 characters
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // company name is optional with a maximum of 150 characters
        [MaxLength(150)]
        public string? CompanyName { get; set; }

        // check whether the organizer is verified
        public bool IsVerified { get; set; }

        // one organizer can have one profile
        public OrganizerProfile? Profile { get; set; }

        // one organizer can create many events
        public List<Event> Events { get; set; } = new();
    }

    #endregion
}
