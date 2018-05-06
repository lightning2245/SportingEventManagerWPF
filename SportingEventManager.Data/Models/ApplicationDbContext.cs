using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;


namespace SportingEventManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Organizer> Organizers { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Guardian> Guardians { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<AgeRange> AgeRanges { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<SportsEvent> SportsEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<AgeRange>()
                        .Property(c => c.Id) // Client must set the ID.
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}