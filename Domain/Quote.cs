namespace SamuraiApp.Domain {
  public class Quote {
    public static Quote Create (string text, int samuraiId) {
      return new Quote (text, samuraiId);
    }
    private Quote (string text, int samuraiId) {
      Text = text;
      SamuraiId = SamuraiId;
    }
    private Quote () { } //ORM requires paramterless ctor
    public int Id { get; private set; }
    public string Text { get; private set; }
    public int SamuraiId { get; private set; }
  }
}