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
    public int Id { get; set; }
    public int MovieMinute { get; set; }
    public string SceneName { get; set; }
    public string ActionDescription { get; set; }
    public int SamuraiFK { get; set; }
  }
}