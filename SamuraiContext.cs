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

      modelBuilder.Entity<Samurai> ()
        .HasOne (typeof (Entrance), "Entrance")
        .WithOne ();

      modelBuilder.Entity<Samurai> ()
        .HasOne (typeof (EntranceWithField), "EntranceWithField")
        .WithOne ();

      modelBuilder.Entity<Samurai> ().OwnsOne (typeof (PersonName), "SecretIdentity");

    }

  }
}