using System;

namespace SamuraiApp.Domain
{

  public class EntranceWithField
  {
 
    public EntranceWithField() { }
    public EntranceWithField(int movieMinute, string sceneName, string description)
    {
      MovieMinute = movieMinute;
      SceneName = sceneName;
      ActionDescription = description;
    }
    public int Id { get; private set; }
    public int MovieMinute { get; private set; }
    public string SceneName { get; private set; }
    public string ActionDescription { get; private set; }
    public int SamuraiFK { get; private set; }
  }
}