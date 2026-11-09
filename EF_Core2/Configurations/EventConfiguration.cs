
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF_Core2
{
    #region Event Configuration - Fluent API

    // configure the Event entity using a separate class
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            // set the primary key
            builder.HasKey(e => e.Id);

            // make the title required
            builder.Property(e => e.Title)
                   .IsRequired();

            // make the description required
            builder.Property(e => e.Description)
                   .IsRequired();

            // link each event to one organizer
            builder.HasOne(e => e.Organizer)
                   .WithMany(o => o.Events)
                   .HasForeignKey(e => e.OrganizerId)
                   .IsRequired();
        }
    }

    #endregion
}
