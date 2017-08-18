using System;

namespace SamuraiApp.Domain {
  public class Quote {
    public static Quote Create (Guid samuraiGuidId,string text) {
      return new Quote (samuraiGuidId,text);
    }
    private Quote (Guid samuraiGuidId,string text) {
      Text = text;
      SamuraiGuidId=samuraiGuidId;
    }
    private Quote () { } //ORM requires paramterless ctor
    public int Id { get; private set; }
    public string Text { get; private set; }
    private int SamuraiId { get;  set; }
    public Guid SamuraiGuidId{get;private set;}
 
  }
}