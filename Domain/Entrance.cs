using System;

namespace SamuraiApp.Domain
{

  public class Entrance
  {
    private Entrance() { } //needed by ORM
    private Entrance(int movieMinute, string sceneName, string description)
    {
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
    }
public static Entrance Create(int movieMinute, string sceneName, string description)
    {
      return new Entrance(movieMinute,sceneName,description);
    }
    public int Id { get; private set; }
    public int MovieMinute { get; private set; }
    public string SceneName { get; private set; }
    public string ActionDescription { get; private set; }
    public int SamuraiId { get; private set; }
  }
}