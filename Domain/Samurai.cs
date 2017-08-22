using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.Domain {
  public class Samurai {
   
    public static Samurai Create (string name) {
      return new Samurai (name);
    }
    private Samurai (string name) : this() {
      Name = name;
      GuidId=Guid.NewGuid();
      IsDirty=true;
    }
    private Samurai () {
      _quotes = new List<Quote> ();
      SecretIdentity = PersonFullName.Empty ();
    }
    public int Id { get; private set; }
    public Guid GuidId{get;private set;}
    public string Name { get; private set; }
    public bool IsDirty {get;private set;}
    #region demonstrates fully encapsulated collection
    private readonly List<Quote> _quotes = new List<Quote> ();

    public IEnumerable<Quote> Quotes => _quotes.ToList ();

    public void AddQuote (string quoteText) {
      _quotes.Add (new Quote(GuidId,quoteText));
      IsDirty=true;
    }
  
#endregion
    #region demonstrates private 1:1 prop with backing field, note mapping in context file
    private Entrance _entrance;
    private Entrance Entrance { get { return _entrance; } }
    public void CreateEntrance (int minute, string sceneName, string description) {
      _entrance = new Entrance (GuidId, minute, sceneName, description);
      IsDirty=true;
    }
    public string EntranceScene => _entrance?.SceneName;
    #endregion

    #region demonstrates private value object with public methods to control how values are set and accessed
    private PersonFullName SecretIdentity { get; set; }
    public string RevealSecretIdentity () {
      if (SecretIdentity.IsEmpty ()) {
        return "It's a secret";
      } else {
        return SecretIdentity.FullName ();
      }
    }
    public void Identify (string first, string last) {
      SecretIdentity = PersonFullName.Create (first, last);
      IsDirty=true;
    }
    #endregion
  }
}