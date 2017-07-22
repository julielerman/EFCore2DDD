using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data {
  public class SamuraiContext : DbContext {

    public SamuraiContext (DbContextOptions<SamuraiContext> options) : base (options) {

    }
    public SamuraiContext () {

    }
    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite ("Filename=DP0917Samurai.db");
      base.OnConfiguring (optionsBuilder);
    }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {

      //Note that we need to configure the model
      //to know about entrance and entrancewithfield
      //before running the code that depends on GetEntityTypes
      modelBuilder.Entity<Samurai> ()
        .HasOne (typeof (Entrance), "Entrance").WithOne ();

      modelBuilder.Entity<Samurai> ()
        .HasOne (typeof (EntranceWithField), "EntranceWithField")
        .WithOne ().HasForeignKey (typeof (EntranceWithField), "SamuraiFK");

      //note this has to come AFTER the hasone/withone config or the 
      //navigation won't be recognized yet
      modelBuilder.Entity<Samurai> ()
        .Metadata
        .FindNavigation ("EntranceWithField")
        .SetField ("_entranceField");

      foreach (var entityType in modelBuilder.Model.GetEntityTypes ()) {
        //LastModified is a shadow property, not props in the classes
        modelBuilder.Entity (entityType.Name).Property<DateTime> ("LastModified");
        //IsDirty is for local tracking, not persisted in the database
        modelBuilder.Entity (entityType.Name).Ignore ("IsDirty");
      }
      //NOTE: owned entity needs to go after the GetEntityTypes or it will be seen as an entity
      modelBuilder.Entity<Samurai> ().OwnsOne (typeof (PersonName), "SecretIdentity");

    }

    public override int SaveChanges () {
      foreach (var entry in ChangeTracker.Entries ()
        .Where (e => e.State == EntityState.Added ||
          e.State == EntityState.Modified)) {
        //ignore owned entities (todo: is there a generic way?)
        if (!(entry.Entity is PersonName))
          entry.Property ("LastModified").CurrentValue = DateTime.Now;
      }
      return base.SaveChanges ();
    }
  }
}