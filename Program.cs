using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace Data_Points_0917_EFCore2Model
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var context = new SamuraiContext())
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
      }
      StoreNewSamuraiWithEntrance();
      StoreNewSamuraiWithEntranceAndIdentity();
      ListSamuraisWithEntranceAndIdentity();
      using (var context = new SamuraiContext())
      {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
      }
    }
    static void StoreNewSamuraiWithEntrance()
    {
      var samurai = Samurai.Create("Julie");
      samurai.CreateEntrance(1, "S1", "Here I am!");
      using (var context = new SamuraiContext())
      {
        context.Samurais.Add(samurai);
        context.SaveChanges();
      }
    }

    static void StoreNewSamuraiWithEntranceAndIdentity()
    {
      var samurai = Samurai.Create("Giantpuppy");
      samurai.Identify("Sampson", "Newfie");
      samurai.CreateEntrance(2, "S2", "Woof!");
      using (var context = new SamuraiContext())
      {
        context.Samurais.Add(samurai);
        context.SaveChanges();
      }
    }
    static void ListSamuraisWithEntranceAndIdentity()
    {
      using (var context = new SamuraiContext())
      {
        var samurais = context.Samurais.Include("Entrance").ToList();
        foreach (var samurai in samurais)
        {
          Console.WriteLine($"{samurai.Name}, Enters in {samurai.EntranceScene} ");
          Console.WriteLine($"Secret Identity: {samurai.RevealSecretIdentity()}");

        }
      }
    }

  }
}