namespace Solinia.Database.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SoliniaContext : DbContext
    {
        public SoliniaContext()
            : base("name=SoliniaContext")
        {
        }

        public virtual DbSet<World> Worlds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<World>()
                .Property(e => e.Name);

            modelBuilder.Entity<Zone>()
                .Property(e => e.Name);
            modelBuilder.Entity<Zone>()
                .Property(e => e.WorldId);

            modelBuilder.Entity<Actor>()
                .Property(e => e.Name);
        }
    }
}
