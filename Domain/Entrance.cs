using System;

namespace SamuraiApp.Domain {

  public class Entrance {
    public static Entrance Create (Guid samuraiGuidId,int movieMinute, string sceneName, string description) {
      return new Entrance (samuraiGuidId,movieMinute, sceneName, description);
    }
    private Entrance (Guid samuraiGuidId,int movieMinute, string sceneName, string description) {
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

    //demonstrates unconventional FK name. Note mapping in context 
    //for the 1:1 relationship to sort this out
    public int SamuraiFk { get; private set; }
    public Guid SamuraiGuidId{get;private set;}
  }
}