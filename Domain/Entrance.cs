using System;

namespace SamuraiApp.Domain {

  public class Entrance {
  
    public Entrance (Guid samuraiGuidId,int movieMinute, string sceneName, string description) {
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
      SamuraiGuidId=samuraiGuidId;
    }
    private Entrance () { } //needed by ORM
    public int Id { get; private set; }
    public int MovieMinute { get; private set; }
    public string SceneName { get; private set; }
    public string ActionDescription { get; private set; }

    //demonstrates unconventional FK name. Also it's private. Note mapping in context 
    //for the 1:1 relationship to sort this out. EF Core will infer a backing property.
    private int SamuraiFk { get;  set; }
    public Guid SamuraiGuidId{get;private set;}
  }
}