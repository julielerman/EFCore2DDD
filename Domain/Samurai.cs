using System;
using System.Collections.Generic;
using System.Linq;

namespace SamuraiApp.Domain {
  public class Samurai {

    public Samurai () {
      _quotes = new List<Quote> ();
      SecretIdentity = PersonName.Empty ();
    }

    public int Id { get; set; }
    public string Name { get; private set; }
    #region demonstrates fully encap
    private readonly List<Quote> _quotes = new List<Quote> ();

    public IEnumerable<Quote> Quotes => _quotes.ToList ();

    public void AddQuote (Quote quote) {
      _quotes.Add (quote);
    }

  #region demonstrates private 1:1 prop with backing field, note mapping in context file
    private Entrance _entrance;
    private Entrance Entrance { get { return _entrance; } }
    public void CreateEntrance (int minute, string sceneName, string description) {
      _entrance = Entrance.Create (minute, sceneName, description);
    }
    public string EntranceScene => _entrance?.SceneName;
  #endregion
  
  #region demonstrates private value object with public methods to control how values are set and accessed
    private PersonName SecretIdentity { get; set; }
    public string RevealSecretIdentity () {
      if (SecretIdentity.IsEmpty ()) {
        return "It's a secret";
      } else {
        return SecretIdentity.FullName ();
      }
    }
    public void Identify (string first, string last) {
      SecretIdentity = PersonName.Create (first, last);
    }
  #endregion
  }
}