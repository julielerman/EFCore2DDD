using System;

namespace SamuraiApp.Domain
{

  public class Entrance
  {
    public Entrance() { }
    public Entrance(int movieMinute, string sceneName, string description)
    {
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
    }
    public int Id { get; set; }
    public int MovieMinute { get; set; }
    public string SceneName { get; set; }
    public string ActionDescription { get; set; }
    public int SamuraiId { get; set; }
  }
}