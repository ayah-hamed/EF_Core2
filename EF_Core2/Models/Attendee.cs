
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core2
{
    #region Attendee - Data Annotations

    // store information about people attending events
    public class Attendee
    {
        // primary key
        public int Id { get; set; }

        // attendee name is required
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        // email is required with a maximum of 200 characters
        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        // street address is required
        [Required]
        [MaxLength(150)]
        public string Street { get; set; } = string.Empty;

        // city is required
        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        // country is required
        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;

        // save postal code in a column named ZipCode
        [Required]
        [MaxLength(20)]
        [Column("ZipCode")]
        public string PostalCode { get; set; } = string.Empty;

        // combine the address without storing it in the database
        [NotMapped]
        public string FullAddress =>
            $"{Street}, {City}, {Country}, {PostalCode}";

        // one attendee can have one badge
        public Badge? Badge { get; set; }
    }

    #endregion
}
