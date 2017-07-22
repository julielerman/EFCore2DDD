using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain {
  public class Samurai {

    public Samurai () {
      Quotes = new List<Quote> ();
      SecretIdentity=PersonName.Empty();
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public List<Quote> Quotes { get; set; }

    #region demonstrates private 1:1 prop with no backing field, note mapping in context file
    private Entrance Entrance { get; set; }
    public void CreateEntrance (int minute, string sceneName, string description) {
      Entrance = new Entrance (minute, sceneName, description);
    }
      public string EntranceScene => Entrance?.SceneName;

    #endregion

    #region demonstrates private 1:1 prop with backing field, note mapping in context file
    private EntranceWithField _entranceField;
    private EntranceWithField EntranceWithField { get{return _entranceField;} }
    public void CreateEntranceWithField (int minute, string sceneName, string description) {
      _entranceField = new EntranceWithField (minute, sceneName, description);
    }
    public string EntranceWithFieldScene => _entranceField?.SceneName;

    #endregion
#if true
    private PersonName SecretIdentity {get;set;} 
    public string RevealSecretIdentity () {
      if (SecretIdentity.IsEmpty()) {
        return "It's a secret";
      } else {
        return SecretIdentity.FullName ();
      }
    }
    public void Identify (string first, string last) {
      SecretIdentity = PersonName.Create (first, last);
    }
#endif
  }
}