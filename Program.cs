using System;
using System.Linq;
using System.Reflection;
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
      StoreNewSamuraiWithNoEntrance();
      StoreNewSamuraiWithEntrance();
      StoreNewSamuraiWithEntranceAndIdentity();
      ListSamuraisWithEntranceAndIdentity();
     
    }
     static void StoreNewSamuraiWithNoEntrance()
    {
      var samurai = Samurai.Create("InvisibleMan");
      using (var context = new SamuraiContext())
      {
        context.Samurais.Add(samurai);
        context.SaveChanges();
      }
    }
    static void StoreNewSamuraiWithEntrance()
    {
      var samurai = Samurai.Create("Julie");
      samurai.CreateEntrance(1, "S1", "Tumbles off a roof");
      samurai.AddQuote("Ouch!");
      samurai.AddQuote("That hurt!");
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
      samurai.CreateEntrance(2, "S2", "Walks in on all fours");
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
          BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
        | BindingFlags.Static;
  
          var myPropInfo = samurai.GetType().GetField("_entrance",bindFlags);
          var myValue = myPropInfo.GetValue(samurai);
          Console.WriteLine($"SamuraiGuid: {samurai.GuidId}, E.SG: {myValue}");
          Console.WriteLine($"Secret Identity: {samurai.RevealSecretIdentity()}");
        }
      }
    }

  }
}