
using Microsoft.EntityFrameworkCore;

namespace EF_Core2
{
    public class EventHubContext : DbContext
    {
        #region DbSets

        // represent the five database tables
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        #endregion

        #region Database Connection

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // connect to sql server using windows authentication
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        #endregion

        #region Fluent API - OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region OrganizerProfile Configuration

            // configure organizer profile using fluent api
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                // set the primary key
                entity.HasKey(p => p.Id);

                // each profile belongs to one organizer
                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.Profile)
                      .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                      .IsRequired();
            });

            #endregion

            #region Badge Configuration

            // configure badge using fluent api
            modelBuilder.Entity<Badge>(entity =>
            {
                // set the primary key
                entity.HasKey(b => b.Id);

                // make each badge number unique
                entity.HasIndex(b => b.BadgeNumber)
                      .IsUnique();

                // store the badge tier as text
                entity.Property(b => b.Tier)
                      .HasConversion<string>()
                      .IsRequired();

                // each badge belongs to one attendee
                entity.HasOne(b => b.Attendee)
                      .WithOne(a => a.Badge)
                      .HasForeignKey<Badge>(b => b.AttendeeId)
                      .IsRequired();
            });

            #endregion

            #region Event Configuration

            // apply fluent api from the separate configuration class
            modelBuilder.ApplyConfiguration(new EventConfiguration());

            #endregion
        }

        #endregion
    }
}
